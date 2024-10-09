using Assets.Scripts.Runtime.CardMatch.Misc;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignalWithInterfaces<ReturnToMainUISignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<StartGameSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<SaveScoreComboSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<LoadGameSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<SettingsSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<QuitGameSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<StartLoadedGameSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateGridSizeSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<LoadScoreComboSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<UpdateScoreValueSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<ResetScoreUISignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<ResetComboValueSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<FlipCardSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<ToggleSaveButtonSignal>().OptionalSubscriber();
            Container.DeclareSignalWithInterfaces<GameOverSignal>().OptionalSubscriber();
        }
    }
}