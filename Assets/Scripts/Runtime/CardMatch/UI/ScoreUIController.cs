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
            _signalBus.Subscribe<UpdateComboValueSignal>(UpdateComboValue);
            _signalBus.Subscribe<ResetScoreUISignal>(ResetScoreUI);
        }

        private void ResetScoreUI(ResetScoreUISignal signal)
        {
            _scoreUIModel.ScoreValue = 0;
            _scoreUIModel.ComboValue = 0;
        }

        private void UpdateScoreValue(UpdateScoreValueSignal signal)
        {
            _scoreUIModel.ScoreValue += signal.newValue;
            _scoreUIModel.ScoreTextValue.text = _scoreUIModel.ScoreValue.ToString();
        }

        private void UpdateComboValue(UpdateComboValueSignal signal)
        {
            _scoreUIModel.ComboValue += signal.newValue;
            _scoreUIModel.ComboTextValue.text = _scoreUIModel.ComboValue.ToString();
        }
    }
}