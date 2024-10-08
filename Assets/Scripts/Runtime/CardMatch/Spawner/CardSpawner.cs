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
        private readonly int _rowCount;
        [Inject(Id = "columnCount")]
        private readonly int _columnCount;
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
            
            _maxCards = _rowCount * _columnCount;

            _maxCards = _maxCards % 2 == 0 ? _maxCards : _maxCards - 1;
        }

        public CardView SpawnCard()
        {
            var cardsPoolCount = _cardPool.Distinct().ToList().Count;
            if (cardsPoolCount >= _maxCards)
            {
                return null;
            }

            var newCard = _cardFactory.Create();
            newCard.SpriteRenderer.sprite = _cardTypes[_cardCount % (_maxCards / 2)].CardSprite;
            _cardCount++;
            var cardRect = newCard.GetComponent<RectTransform>();
            cardRect.sizeDelta = _cellSize;
            _cardPool.Add(newCard);
            return newCard;
        }

        public void RemoveCard(CardView card)
        {
            while (_cardPool.Contains(card))
            {
                _cardPool.Remove(card);
                card.Dispose();
            }
        }

        private void StartGame(StartGameSignal signal)
        {
            CardView spawnedCard;
            _cardCount = 0;
            SetGridCellDimensions();
            do
            {
                spawnedCard = SpawnCard();
            } while (spawnedCard != null);
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