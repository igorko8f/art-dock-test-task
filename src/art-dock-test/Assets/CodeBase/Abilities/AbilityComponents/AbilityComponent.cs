using System;
using System.Collections;
using UniRx;

namespace CodeBase.Abilities.AbilityComponents
{
    public class AbilityComponent : IDisposable
    {
        protected CompositeDisposable _compositeDisposable = new();
        
        public virtual IEnumerator PlayEffect()
        {
            yield return null;
        }

        public virtual void OnEffectPlayed()
        {
            
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }

        protected IEnumerator HoldUntilIsNoValueInObservable<T>(ReactiveProperty<T> observable) where T : class
        {
            var hasValue = observable.Value != null;
            if (hasValue) yield return null;

            observable.ObserveEveryValueChanged(x => x.Value)
                .Subscribe(value => hasValue = value != null)
                .AddTo(_compositeDisposable);
            
            while (hasValue == false)
            {
                yield return null;
            }
        }
    }
}