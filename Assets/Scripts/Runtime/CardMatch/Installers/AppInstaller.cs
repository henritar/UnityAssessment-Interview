using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            GameSignalsInstaller.Install(Container);
        }
    }
}