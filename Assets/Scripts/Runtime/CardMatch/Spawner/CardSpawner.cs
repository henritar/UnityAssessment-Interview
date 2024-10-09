using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Installers;
using Assets.Scripts.Runtime.CardMatch.Misc;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Spawner
{
    public class CardSpawner : IInitializable
    {
        [Inject(Id = "rowCount")]
        private  int _rowCount;
        [Inject(Id = "columnCount")]
        private  int _columnCount;
        [Inject(Id = "cardTypes")]
        private readonly MainSceneInstaller.CardType[] _cardTypes;
        private readonly IFactory<CardView> _cardFactory;
        private readonly GridLayoutGroup _gridLayout;
        private readonly SignalBus _signalBus;

        private List<CardView> _cardPool = new List<CardView>();
        private Vector2 _cellSize;
        private int _cardCount;
        private int _maxCards;

        public CardSpawner(CardView.Factory factory, GridLayoutGroup gridLayout, SignalBus signalBus)
        {
            _cardFactory = factory;
            _gridLayout = gridLayout;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<StartGameSignal>(StartGame);
            _signalBus.Subscribe<UpdateScoreValueSignal>(ConsumeCard);
            _signalBus.Subscribe<UpdateGridSizeSignal>(UpdateGridSize);
        }

        public CardView SpawnCard()
        {
            var cardsPoolCount = _cardPool.Distinct().ToList().Count;
            if (cardsPoolCount >= _maxCards)
            {
                return null;
            }

            var newCard = _cardFactory.Create();

            MainSceneInstaller.CardType cardType = _cardTypes[_cardCount % (_maxCards / 2)];
            newCard.gameObject.name = $"card{cardType.CardId}";
            newCard.SpriteRenderer.sprite = cardType.CardSprite;
            _cardCount++;

            var cardRect = newCard.GetComponent<RectTransform>();
            cardRect.sizeDelta = _cellSize;

            Vector2 spriteSize = newCard.SpriteRenderer.sprite.bounds.size;

            float scaleX = _cellSize.x / spriteSize.x;
            float scaleY = _cellSize.y / spriteSize.y;

            newCard.transform.localScale = new Vector3(scaleX, scaleY, 1f);
            newCard.SpriteRenderer.enabled = true;

            _cardPool.Add(newCard);
            return newCard;
        }

        private void ClearPool()
        {
            foreach (var card in _cardPool)
            {
                card.Dispose();
            }
            _cardPool.Clear();
        }

        private void StartGame(StartGameSignal signal)
        {
            _maxCards = _rowCount * _columnCount;
            _maxCards = _maxCards % 2 == 0 ? _maxCards : _maxCards - 1;
            _cardCount = 0;
            
            SetGridCellDimensions();
            CardView spawnedCard;
            do
            {
                spawnedCard = SpawnCard();
            } while (spawnedCard != null);
        }

        private void ConsumeCard(UpdateScoreValueSignal signal)
        {
            _cardCount -= 2;
            if (_cardCount <= 0)
            {
                ClearPool();
                _signalBus.Fire(new GameOverSignal());
            }
        }

        private void UpdateGridSize(UpdateGridSizeSignal signal)
        {
            switch (signal.modifier)
            {
                case Enum.GridSizeModifier.add:
                    _rowCount += signal.rowCount;
                    _columnCount += signal.columnCount;
                    break;
                case Enum.GridSizeModifier.subtract:
                    _rowCount -= signal.rowCount;
                    _columnCount -= signal.columnCount;
                    break;
                case Enum.GridSizeModifier.substitute:
                    _rowCount = signal.rowCount;
                    _columnCount = signal.columnCount;
                    break;
                default:
                    break;
            }
        }

        private void SetGridCellDimensions()
        {
            RectTransform gridRectTransform = _gridLayout.GetComponent<RectTransform>();
            float containerWidth = gridRectTransform.rect.width;
            float containerHeight = gridRectTransform.rect.height;

            Vector2 spacing = _gridLayout.spacing;
            RectOffset padding = _gridLayout.padding;

            float cellWidth = (containerWidth - padding.left - padding.right - spacing.x * (_columnCount - 1)) / _columnCount;
            float cellHeight = (containerHeight - padding.top - padding.bottom - spacing.y * (_rowCount - 1)) / _rowCount;

            _cellSize = new Vector2(cellWidth, cellHeight);
            _gridLayout.cellSize = _cellSize;
        }
    }
}