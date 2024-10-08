using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Misc;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Handler
{
    public class CardComparerHandler : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus;

        private ReactiveCollection<CardController> _reactiveList = new();

        public CardComparerHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _reactiveList
             .ObserveAdd()
             .Buffer(2)
             .Subscribe(pairOfElements =>
             {
                 ComparePairOfCards(pairOfElements[0].Value, pairOfElements[1].Value);
             });

            _signalBus.Subscribe<FlipCardSignal>(AddCardToCollection);
        }

        private void AddCardToCollection(FlipCardSignal signal)
        {
            Debug.Log("Card added!");
            _reactiveList.Add(signal.cardFlipped);
        }

        private void ComparePairOfCards(CardController card1, CardController card2)
        {
            Debug.Log("Comparing Cards!");
            if (card1.Compare(card2))
            {
                Debug.Log("Cards Match!");
                card1.MatchCard();
                card2.MatchCard();
            }
            else
            {
                Debug.Log("Wrong cards...");
                card1.Flip();
                card2.Flip();
            }

            _reactiveList.Remove(card1);
            _reactiveList.Remove(card2);
        }

        public void Dispose()
        {
            _reactiveList.Clear();
            _reactiveList.Dispose();
        }
    }
}