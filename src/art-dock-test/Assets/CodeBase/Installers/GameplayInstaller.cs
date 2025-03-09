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

    [SerializeField] private PlayerBase _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;
    
    public override void InstallBindings()
    {
        BindInputService();
        BindWindowsManagementService();
        BindMainCameraService();

        BindPlayer();
    }

    private void BindPlayer()
    {
        Container.Bind<PlayerBase>()
            .FromComponentInNewPrefab(_playerPrefab)
            .AsSingle()
            .WithArguments(_playerSpawnPoint)
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
