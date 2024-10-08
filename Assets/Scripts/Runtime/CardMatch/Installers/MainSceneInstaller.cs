using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Misc;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Inject(Id = "cards")]
        CardSettings _cardSettings;

        public override void InstallBindings()
        {
            Container.Bind<AudioPlayer>().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MainSceneInstaller.CardType[]>().FromInstance(_cardSettings.CardTypesList);


            Container.BindFactory<CardView, CardView.Factory>().FromPoolableMemoryPool<CardView, CardView.CardViewPool>(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<CardInstaller>(_cardSettings.CardPrefab).UnderTransformGroup("CardsGrid"));
        }

        [Serializable]
        public class CardSettings
        {
            public GameObject CardPrefab;
            public CardType[] CardTypesList;
            public int RowCount;
            public int ColumnCount;
        }

        [Serializable]
        public class CardType
        {
            public Sprite CardSprite;
            public int CardId;
        }
    }
}

    