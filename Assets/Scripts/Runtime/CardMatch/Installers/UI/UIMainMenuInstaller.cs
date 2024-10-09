using Assets.Scripts.Runtime.CardMatch.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers.UI
{
    public class UIMainMenuInstaller : MonoInstaller
    {
        [SerializeField] public Canvas MainUICanvas;
        [SerializeField] public Button StartGameButton;
        [SerializeField] public Button LoadGameButton;
        [SerializeField] public Button SettingsButton;
        [SerializeField] public Button QuitButton;
        [SerializeField] public Toggle TwoTwoToggle;
        [SerializeField] public Toggle ThreeThreeToogle;
        [SerializeField] public Toggle FourThreeToggle;
        [SerializeField] public Toggle FiveFourToggle;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainUIController>().AsSingle();
            Container.Bind<MainUIModel>().AsSingle().WhenInjectedInto<MainUIController>();
            Container.BindInterfacesAndSelfTo<MainUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<MainUIController>();

            Container.BindInstance(MainUICanvas).WithId("mainUICanvas").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(StartGameButton).WithId("startGameButton").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(LoadGameButton).WithId("loadGameButton").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(SettingsButton).WithId("settingsButton").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(QuitButton).WithId("quitButton").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(TwoTwoToggle).WithId("TwoTwoToggle").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(ThreeThreeToogle).WithId("ThreeThreeToogle").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(FourThreeToggle).WithId("FourThreeToggle").WhenInjectedInto<MainUIModel>();
            Container.BindInstance(FiveFourToggle).WithId("FiveFourToggle").WhenInjectedInto<MainUIModel>();
        }
    }
}