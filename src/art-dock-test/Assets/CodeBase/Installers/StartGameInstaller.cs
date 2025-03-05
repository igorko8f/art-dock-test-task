using CodeBase.Systems.GameStateMachine;
using CodeBase.Systems.GameStateMachine.States;
using Zenject;

namespace CodeBase.Installers
{
    public class StartGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            
        }

        public override void Start()
        {
            var gamePlayStateMachine = Container.Resolve<IGameStateMachine>();
            
            gamePlayStateMachine.BindStates();
            
            gamePlayStateMachine.Enter<BootstrapState>();
        }
    }
}