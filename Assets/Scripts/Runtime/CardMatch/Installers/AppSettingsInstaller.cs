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
            Container.BindInstance(CardSettings.CardPrefab).WithId("cardPrefab").IfNotBound();
            Container.BindInstance(CardSettings.CardBack).WithId("cardBack").IfNotBound();
            Container.BindInstance(CardSettings.CardParentName).WithId("cardParentName").IfNotBound();
            Container.BindInstance(CardSettings.CardTypesList).WithId("cardTypes").IfNotBound();
            Container.BindInstance(CardSettings.RowCount).WithId("rowCount").IfNotBound();
            Container.BindInstance(CardSettings.ColumnCount).WithId("columnCount").IfNotBound();
        }
    }
}