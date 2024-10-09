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
            _signalBus.Subscribe<UpdateScoreValueSignal>(UpdateScoreValue);
            _signalBus.Subscribe<ResetComboValueSignal>(ResetComboValue);
            _signalBus.Subscribe<ResetScoreUISignal>(ResetScoreUI);
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
    }
}