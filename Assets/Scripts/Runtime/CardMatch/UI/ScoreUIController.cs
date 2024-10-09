using Assets.Scripts.Runtime.CardMatch.Handler;
using Assets.Scripts.Runtime.CardMatch.Misc;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.UI
{
    public class ScoreUIController : IInitializable
    {
        private readonly ScoreUIView _scoreUIView;
        private readonly ScoreUIModel _scoreUIModel;
        private readonly SignalBus _signalBus;

        public ScoreUIController(ScoreUIView scoreUIView, ScoreUIModel scoreUIModel, SignalBus signalBus)
        {
            _scoreUIView = scoreUIView;
            _scoreUIModel = scoreUIModel;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _scoreUIModel.SaveGameButton.gameObject.SetActive(false);
            _scoreUIModel.ReturnButton.gameObject.SetActive(false);
            _signalBus.Subscribe<UpdateScoreValueSignal>(UpdateScoreValue);
            _signalBus.Subscribe<ResetComboValueSignal>(ResetComboValue);
            _signalBus.Subscribe<ResetScoreUISignal>(ResetScoreUI);
            _signalBus.Subscribe<ToggleSaveButtonSignal>(ToggleSaveButton);
            _signalBus.Subscribe<StartLoadedGameSignal>(StartLoadedGame);

            _scoreUIModel.SaveGameButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new SaveScoreComboSignal() { combo = _scoreUIModel.ComboValue, score = _scoreUIModel.ScoreValue});
            });
            _scoreUIModel.ReturnButton.onClick.AddListener(() =>
            {
                _signalBus.Fire(new ReturnToMainUISignal());
            });
        }

        private void ResetScoreUI(ResetScoreUISignal signal)
        {
            _scoreUIModel.ScoreValue = 0;
            _scoreUIModel.ComboValue = 0;
            UpdateScoreComboText();
        }

        private void UpdateScoreValue(UpdateScoreValueSignal signal)
        {
            _scoreUIModel.ScoreValue += 5 * ++_scoreUIModel.ComboValue;
            UpdateScoreComboText();
        }

        private void ResetComboValue(ResetComboValueSignal signal)
        {
            _scoreUIModel.ComboValue = 0;
            UpdateScoreComboText();
        }
        private void UpdateScoreComboText()
        {
            _scoreUIModel.ComboTextValue.text = _scoreUIModel.ComboValue.ToString();
            _scoreUIModel.ScoreTextValue.text = _scoreUIModel.ScoreValue.ToString();
        }

        private void ToggleSaveButton(ToggleSaveButtonSignal signal)
        {
            _scoreUIModel.SaveGameButton.gameObject.SetActive(signal.showButton);
            _scoreUIModel.ReturnButton.gameObject.SetActive(signal.showButton);
        }
        
        private void StartLoadedGame(StartLoadedGameSignal signal)
        {
            SaveGameStateHandler.GameInfo gameInfo = SaveGameStateHandler.LoadGameInfo();
            _scoreUIModel.ScoreValue = gameInfo.score;
            _scoreUIModel.ComboValue = gameInfo.combo;
            UpdateScoreComboText();
        }
    }
}