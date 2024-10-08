using Assets.Scripts.Runtime.CardMatch.Misc;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class MainUIController : IInitializable
    {
        readonly MainUIModel _model;
        readonly MainUIView _view;
        readonly SignalBus _signalBus;

        public MainUIController(MainUIModel model, MainUIView view, SignalBus signalBus)
        {
            _model = model;
            _view = view;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ReturnToMainUISignal>(ResetMainUI);

            _model.StartGameButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new StartGameSignal());
                _model.MainUICanvas.enabled = false;
            });

            _model.LoadGameButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new LoadGameSignal());
                _model.MainUICanvas.enabled = false;
            });

            _model.SettingsButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new SettingsSignal());
                _model.MainUICanvas.enabled = false;
            });

            _model.QuitButton.onClick.AddListener(() =>
            {
                Debug.Log("Quit game!");
                QuitGame();
            });

        }

        private void ResetMainUI(ReturnToMainUISignal signal)
        {
            _model.MainUICanvas.enabled = true;
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}