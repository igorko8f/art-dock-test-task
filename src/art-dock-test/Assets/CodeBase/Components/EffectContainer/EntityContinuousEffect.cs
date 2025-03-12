using System;
using CodeBase.Abilities.Enums;
using UniRx;

namespace CodeBase.Components.EffectContainer
{
    public class EntityContinuousEffect : IDisposable
    {
        public float Duration;
        public float Delay;
        public float Value;
        public AbilityDamageType AbilityDamageType;

        public IDisposable Timer;
        
        private CompositeDisposable _compositeDisposable = new();
        
        private float _currentTime = 0f;

        public EntityContinuousEffect(float duration, float delay, float value, AbilityDamageType damageType, Action<float, AbilityDamageType> onEffectApply, 
            Action<EntityContinuousEffect> onEffectEnd)
        {
            Duration = duration;
            Delay = delay;
            Value = value;
            AbilityDamageType = damageType;

            onEffectApply?.Invoke(Value, AbilityDamageType);
            
            Timer = Observable
                .Timer(System.TimeSpan.FromSeconds(Delay))
                .RepeatSafe()
                .Subscribe(x =>
                {
                    CheckTimerFinished(onEffectApply, onEffectEnd);
                })
                .AddTo(_compositeDisposable);
        }

        private void CheckTimerFinished(Action<float, AbilityDamageType> onEffectApply, Action<EntityContinuousEffect> onEffectEnd)
        {
            _currentTime += Delay;
            onEffectApply?.Invoke(Value, AbilityDamageType);
            
            if (_currentTime >= Duration)
            {
                _compositeDisposable?.Dispose();
                onEffectEnd?.Invoke(this);
            }
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}