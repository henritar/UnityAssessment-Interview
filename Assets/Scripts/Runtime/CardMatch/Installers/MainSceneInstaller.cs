using Assets.Scripts.Runtime.CardMatch.Misc;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Runtime.CardMatch.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AudioPlayer>().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }
    }
}