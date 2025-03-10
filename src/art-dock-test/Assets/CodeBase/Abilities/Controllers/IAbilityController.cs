using System;

namespace CodeBase.Abilities.Controllers
{
    public interface IAbilityController : IDisposable
    {
        void ConstructAbilitySequences(AbilityConfig[] configs);
    }
}