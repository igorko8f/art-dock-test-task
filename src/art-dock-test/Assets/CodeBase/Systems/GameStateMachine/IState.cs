namespace CodeBase.Systems.GameStateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}