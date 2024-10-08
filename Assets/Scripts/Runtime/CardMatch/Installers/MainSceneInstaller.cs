using Assets.Scripts.Runtime.CardMatch.Cards;
using Assets.Scripts.Runtime.CardMatch.Handler;
using Assets.Scripts.Runtime.CardMatch.Misc;
using Assets.Scripts.Runtime.CardMatch.Spawner;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [Inject(Id = "cardPrefab")]
        private readonly GameObject _cardPrefab;
        [Inject(Id = "cardParentName")]
        private readonly string _cardParentName;

        public override void InstallBindings()
        {
            Container.Bind<AudioPlayer>().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<CardSpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<CardComparerHandler>().AsSingle();

            var cardParent = GameObject.Find(_cardParentName).GetComponent<GridLayoutGroup>();

            Container.BindInstance(cardParent).AsSingle();

            Container.BindFactory<CardView, CardView.Factory>().FromPoolableMemoryPool<CardView, CardView.CardViewPool>(pool => pool.WithInitialSize(10).ExpandByDoubling()
                .FromSubContainerResolve().ByNewPrefabInstaller<CardInstaller>(_cardPrefab).UnderTransform(cardParent.transform));
        }

        [Serializable]
        public class CardSettings
        {
            public GameObject CardPrefab;
            public string CardParentName;
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

    