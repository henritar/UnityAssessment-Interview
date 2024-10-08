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
        }

        private void UpdateScoreValue(UpdateScoreValueSignal signal)
        {
            _scoreUIModel.ScoreValue.text = signal.newValue.ToString();
        }

        private void UpdateComboValue(UpdateComboValueSignal signal)
        {
            _scoreUIModel.ComboValue.text = signal.newValue.ToString();
        }
    }
}