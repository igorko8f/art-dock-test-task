namespace CodeBase.Systems.GameStateMachine
{
    public interface IPayloadedState : IExitableState
    {
        void Enter<TPayload>(TPayload payload);
    }
}