using System;
using System.Collections;

namespace CodeBase.Abilities.AbilityComponents
{
    public class AbilityComponent : IDisposable
    {
        public virtual IEnumerator PlayEffect()
        {
            yield return null;
        }

        public void Dispose()
        {
        }
    }
}