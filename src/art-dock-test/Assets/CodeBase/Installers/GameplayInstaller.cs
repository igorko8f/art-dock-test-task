using CodeBase.Services.MainCameraService;
using CodeBase.Services.WindowsManagementService;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private WindowsManagementService _windowsManagementService;
    [SerializeField] private Camera _mainCamera;
    
    public override void InstallBindings()
    {
        BindWindowsManagementService();
        BindMainCameraService();
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
