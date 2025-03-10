using System;
using UniRx;

namespace CodeBase.Abilities.Controllers
{
    public interface IAbilitySequence : IDisposable
    {
        IObservable<Unit> Play();
    }
}