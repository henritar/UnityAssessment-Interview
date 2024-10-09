using Assets.Scripts.Runtime.CardMatch.Cards;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class CardInstaller : Installer<CardInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CardController>().AsSingle();
            Container.Bind<CardModel>().AsSingle().WhenInjectedInto<CardController>();
            Container.Bind<CardView>().FromComponentOnRoot().AsSingle();
            Container.Bind<Animator>().FromComponentOnRoot().AsSingle();
        }
    }
}