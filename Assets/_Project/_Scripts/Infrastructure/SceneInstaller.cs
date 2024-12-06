using Assets._Project._Scripts.Components;
using Assets._Project._Scripts.Views;
using UnityEngine;
using Zenject;

namespace Assets._Project._Scripts.Infrastructure
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private CameraFollow _cameraPrefab;
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private Player _playerPrefab;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Player>().FromComponentsInNewPrefab(_playerPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<GameUI>().FromComponentsInNewPrefab(_gameUI).AsSingle();
            Container.BindInterfacesAndSelfTo<GameUIController>().AsSingle();

            Container.BindInterfacesTo<PlayerKeyboardBinder>().AsSingle();

            Container.Bind<SceneController>().AsSingle();
            Container.Bind<CameraFollow>().FromComponentsInNewPrefab(_cameraPrefab).AsSingle().NonLazy();

        }
    }
}