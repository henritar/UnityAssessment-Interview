using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    [CreateAssetMenu(fileName = "AppSettingsInstaller", menuName = "Installers/AppSettingsInstaller")]
    public class AppSettingsInstaller : ScriptableObjectInstaller<AppSettingsInstaller>
    {
        [SerializeField] private MainSceneInstaller.CardSettings CardSettings;
       

        public override void InstallBindings()
        {
            Container.BindInstance(CardSettings).WithId("cards").IfNotBound();
            Container.BindInstance(CardSettings.CardTypesList).WithId("cardTypes").IfNotBound();
        }
    }
}