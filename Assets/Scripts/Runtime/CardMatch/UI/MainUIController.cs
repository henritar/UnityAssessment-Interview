using Assets.Scripts.Runtime.CardMatch.Misc;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class MainUIController : IInitializable
    {
        readonly MainUIModel _model;
        readonly MainUIView _view;
        readonly SignalBus _signalBus;
        private Toggle _activeToggle;
        public MainUIController(MainUIModel model, MainUIView view, SignalBus signalBus)
        {
            _model = model;
            _view = view;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<ReturnToMainUISignal>(ResetMainUI);
            _activeToggle = _model.TwoTwoToggle;
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

            _model.ResetButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new ResetScoreUISignal());
            });

            _model.QuitButton.onClick.AddListener(() =>
            {
                Debug.Log("Quit game!");
                QuitGame();
            });

            _model.TwoTwoToggle.onValueChanged.AddListener(isOn => {
                _activeToggle = _model.TwoTwoToggle;
                OnToggleChanged(isOn, 2, 2); 
            });
            _model.ThreeThreeToogle.onValueChanged.AddListener(isOn => {
                _activeToggle = _model.ThreeThreeToogle;
                OnToggleChanged(isOn, 3, 3);
            });
            _model.FourThreeToggle.onValueChanged.AddListener(isOn => {
                _activeToggle = _model.FourThreeToggle;
                OnToggleChanged(isOn, 4, 3);
            });
            _model.FiveFourToggle.onValueChanged.AddListener(isOn => {
                _activeToggle = _model.FiveFourToggle;
                OnToggleChanged(isOn, 5, 4);
            });
            _model.FiveFiveToggle.onValueChanged.AddListener(isOn => {
                _activeToggle = _model.FiveFiveToggle;
                OnToggleChanged(isOn, 5, 5);
            });
            _model.SixSixToggle.onValueChanged.AddListener(isOn => {
                _activeToggle = _model.SixSixToggle;
                OnToggleChanged(isOn, 6, 6);
            });

        }

        void OnToggleChanged(bool isOn, int rowCount, int columnCount)
        {
            if (isOn)
            {
                Debug.Log($"Toggle for {rowCount}x{columnCount} grid size selected!");
                _signalBus.Fire(new UpdateGridSizeSignal() { columnCount = columnCount, rowCount = rowCount, modifier = Enum.GridSizeModifier.substitute });
            }
        }

        private void ResetMainUI(ReturnToMainUISignal signal)
        {
            _model.MainUICanvas.enabled = true;
            _activeToggle.onValueChanged.Invoke(_activeToggle.isOn);
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