using System;

namespace CodeBase.Abilities.AbilityComponents
{
    public class AbilityComponent : IDisposable
    {
        public virtual void PlayEffect()
        {
        }

        public void Dispose()
        {
        }
    }
}