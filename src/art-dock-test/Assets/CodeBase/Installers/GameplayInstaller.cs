using CodeBase.Abilities.Controllers;
using CodeBase.Components.Enemy;
using CodeBase.Components.Player;
using CodeBase.Services.InputService;
using CodeBase.Services.MainCameraService;
using CodeBase.Services.WindowsManagementService;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private WindowsManagementService _windowsManagementService;
    [SerializeField] private Camera _mainCamera;
    
    [SerializeField] private Transform _playerSpawnPoint;
    
    public override void InstallBindings()
    {
        BindInputService();
        BindWindowsManagementService();
        BindMainCameraService();

        BindPlayer();
        BindEnemies();
    }

    private void BindPlayer()
    {
        Container.Bind<IPlayerHolder>()
            .To<PlayerHolder>()
            .AsSingle()
            .WithArguments(_playerSpawnPoint)
            .NonLazy();

        Container.Bind<IAbilityController>()
            .To<AbilityController>()
            .AsSingle();
    }

    private void BindEnemies()
    {
        Container.Bind<IEnemyFactory>()
            .To<EnemyFactory>()
            .AsSingle()
            .NonLazy();

        Container.Bind<IEnemiesHolder>()
            .To<EnemiesHolder>()
            .AsSingle()
            .NonLazy();
    }

    private void BindInputService()
    {
        Container.Bind<IInputService>()
            .To<InputService>()
            .AsSingle()
            .NonLazy();
    }

    private void BindMainCameraService()
    {
        Container.Bind<IMainCameraService>()
            .To<MainCameraService>()
            .AsSingle()
            .WithArguments(_mainCamera);
    }

    private void BindWindowsManagementService()
    {
        Container.Bind<IWindowsManagementService>()
            .FromComponentInNewPrefab(_windowsManagementService)
            .AsSingle()
            .NonLazy();
    }
}
