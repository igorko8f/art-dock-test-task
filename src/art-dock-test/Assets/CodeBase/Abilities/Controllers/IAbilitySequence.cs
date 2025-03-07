using System;

namespace CodeBase.Abilities.Controllers
{
    public interface IAbilitySequence : IDisposable
    {
        void Play();
    }
}