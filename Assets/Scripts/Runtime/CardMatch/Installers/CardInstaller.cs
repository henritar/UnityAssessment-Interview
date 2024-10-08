using Assets.Scripts.Runtime.CardMatch.Cards;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class CardInstaller : Installer<CardInstaller>
    {
        [Inject(Id = "cardTypes")]
        private readonly MainSceneInstaller.CardType[] _cardTypes;

        private int _cardCount = 0;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CardController>().AsSingle();
            Container.Bind<CardModel>().AsSingle().WhenInjectedInto<CardController>();
            Container.Bind<CardView>().FromComponentOnRoot().AsSingle();

            Container.BindInstance(_cardTypes[_cardCount % _cardTypes.Length]);
            _cardCount++;
        }
    }
}