using Assets.Scripts.Runtime.CardMatch.Misc;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Handler
{
    public class GameOverHandler : IInitializable
    {
        private readonly SignalBus _signalBus;

        public GameOverHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GameOverSignal>(GameOver);
        }

        private void GameOver(GameOverSignal signal)
        {
            Debug.Log("GAME OVER!");
            _signalBus.Fire(new ReturnToMainUISignal());
        }

    }
}