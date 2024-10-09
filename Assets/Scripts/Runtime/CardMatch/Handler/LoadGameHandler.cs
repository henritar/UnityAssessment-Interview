using Assets.Scripts.Runtime.CardMatch.Misc;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Handler
{
    public class LoadGameHandler : IInitializable
    {
        private readonly SignalBus _signalBus;

        public LoadGameHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<LoadGameSignal>(LoadGame);
        }

        private void LoadGame(LoadGameSignal signal)
        {
            SaveGameStateHandler.GameInfo gameInfo = SaveGameStateHandler.LoadGameInfo();
            _signalBus.Fire(new UpdateGridSizeSignal() { columnCount = gameInfo.columns, rowCount = gameInfo.rows, modifier = Enum.GridSizeModifier.substitute });
            _signalBus.Fire(new LoadScoreComboSignal() { score = gameInfo.score, combo = gameInfo.combo });
            _signalBus.Fire(new StartLoadedGameSignal());
        }
    }
}