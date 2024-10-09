using Assets.Scripts.Runtime.CardMatch.UI;
using TMPro;
using UnityEngine;
using Zenject;

public class UIScoreInstaller : MonoInstaller
{
    [SerializeField] private TextMeshProUGUI _scoreValue;
    [SerializeField] private TextMeshProUGUI _comboValue;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ScoreUIController>().AsSingle();
        Container.Bind<ScoreUIModel>().AsSingle().WhenInjectedInto<ScoreUIController>();
        Container.BindInterfacesAndSelfTo<ScoreUIView>().FromComponentInHierarchy().AsSingle().WhenInjectedInto<ScoreUIController>();

        Container.BindInstance(_scoreValue).WithId("scoreValueText").WhenInjectedInto<ScoreUIModel>();
        Container.BindInstance(_comboValue).WithId("comboValueText").WhenInjectedInto<ScoreUIModel>();
    }
}