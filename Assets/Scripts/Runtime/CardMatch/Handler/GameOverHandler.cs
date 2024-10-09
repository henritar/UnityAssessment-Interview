using Assets.Scripts.Runtime.CardMatch.Installers;
using Assets.Scripts.Runtime.CardMatch.Misc;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Handler
{
    public class GameOverHandler : IInitializable
    {
        [Inject(Id = "audioSettings")]
        private readonly MainSceneInstaller.AudioClipsSettings _audioSettings;
        private readonly AudioPlayer _audioPlayer;
        private readonly SignalBus _signalBus;

        public GameOverHandler(AudioPlayer audioPlayer, SignalBus signalBus)
        {
            _audioPlayer = audioPlayer;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<GameOverSignal>(GameOver);
        }

        private void GameOver(GameOverSignal signal)
        {
            Debug.Log("GAME OVER!");
            _audioPlayer.Play(_audioSettings.GameOverAudio);
            _signalBus.Fire(new ToggleSaveButtonSignal() {  showButton = false });
            _signalBus.Fire(new ReturnToMainUISignal());
        }
    }
}