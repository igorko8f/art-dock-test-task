namespace Codebase.Systems.EventBroker.Handlers
{
    public interface IEntityPlayEffectsHandler : ISubscriber
    {
        void OnEntityPlayEffects();
    }
}