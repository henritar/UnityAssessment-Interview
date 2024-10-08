using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Installers;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Spawner
{
    public class CardSpawner : IInitializable, ITickable
    {
        private readonly MainSceneInstaller.CardSettings _cardSettings;

        private IFactory<CardView> _cardFactory;
        private List<CardView> _cardPool = new List<CardView>();
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            throw new System.NotImplementedException();
        }

        public CardView SpawnCard()
        {
            var cardsPoolCount = _cardPool.Distinct().ToList().Count;
            if (cardsPoolCount >= _cardSettings.RowCount * _cardSettings.ColumnCount)
            {
                return null;
            }

            var newCard = _cardFactory.Create();
            return newCard;
        }
    }
}