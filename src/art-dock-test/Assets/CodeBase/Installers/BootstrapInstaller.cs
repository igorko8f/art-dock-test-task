using CodeBase.Services.ProjectResourcesProvider;
using Codebase.Systems.CommandSystem;
using CodeBase.Systems.CoroutineRunner;
using Codebase.Systems.EventBroker;
using CodeBase.Systems.GameStateMachine;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private CoroutineRunner CoroutineRunner;
    
    public override void InstallBindings()
    {
        BindServices();
    }

    private void BindServices()
    {
        BindEventBrokerService();
        BindCommandDispacher();
        BindProjectResourcesProvider(); 
        BindCoroutineRunner();
        BindGameStateMachine();
    }

    private void BindProjectResourcesProvider()
    {
        Container
            .Bind<IProjectResourcesProvider>()
            .To<ProjectResourcesProvider>()
            .AsSingle();
    }

    private void BindCoroutineRunner()
    {
        Container
            .Bind<ICoroutineRunner>()
            .FromComponentInNewPrefab(CoroutineRunner)
            .AsSingle()
            .NonLazy();
    }

    private void BindCommandDispacher()
    {
        Container.Bind<ICommandBinder>()
            .To<CommandBinder>()
            .AsSingle();

        Container
            .Bind<ICommandDispatcher>()
            .To<CommandDispatcher>()
            .AsSingle();
    }

    private void BindEventBrokerService()
    {
        Container
            .Bind<IEventBrokerService>()
            .To<EventBrokerService>()
            .AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container
            .Bind<IGameStateMachine>()
            .To<GameStateMachine>()
            .AsSingle();
    }
}
