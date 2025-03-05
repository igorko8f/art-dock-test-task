namespace CodeBase.Systems.GameStateMachine
{
    public interface IGameStateMachine
    {
        void BindStates();
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState;
    }
}