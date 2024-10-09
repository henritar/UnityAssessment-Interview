using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Installers;
using Assets.Scripts.Runtime.CardMatch.Misc;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Handler
{
    public class CardComparerHandler : IInitializable, IDisposable
    {
        [Inject(Id = "audioSettings")]
        private readonly MainSceneInstaller.AudioClipsSettings _audioSettings;
        private readonly AudioPlayer _audioPlayer;
        private readonly SignalBus _signalBus;

        private ReactiveCollection<CardController> _reactiveList = new();

        public CardComparerHandler(AudioPlayer audioPlayer, SignalBus signalBus)
        {
            _audioPlayer = audioPlayer;
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
                _signalBus.Fire(new UpdateScoreValueSignal());
                _audioPlayer.Play(_audioSettings.MatchedCardAudio);
                card1.MatchCard();
                card2.MatchCard();
            }
            else
            {
                Debug.Log("Wrong cards...");
                _signalBus.Fire(new ResetComboValueSignal());
                _audioPlayer.Play(_audioSettings.MismatchCardAudio);
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