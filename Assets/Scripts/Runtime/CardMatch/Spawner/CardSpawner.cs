using Assets.Scripts.Runtime.CardMatch.Cards;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IFactory<CardView> _cardFactory;
        private readonly GridLayoutGroup _gridLayout;

        private List<CardView> _cardPool = new List<CardView>();

        public CardSpawner(CardView.Factory factory, GridLayoutGroup gridLayout)
        {
            _cardFactory = factory;
            _gridLayout = gridLayout;
        }

        public void Initialize()
        {
            CardView spawnedCard;

            do
            {
                spawnedCard = SpawnCard();
            } while (spawnedCard != null);
        }

        public CardView SpawnCard()
        {
            var cardsPoolCount = _cardPool.Distinct().ToList().Count;
            if (cardsPoolCount >= _rowCount * _columnCount)
            {
                return null;
            }

            var newCard = _cardFactory.Create();
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
    }
}