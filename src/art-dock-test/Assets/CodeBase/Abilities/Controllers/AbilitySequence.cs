using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Abilities.AbilityComponents;
using UniRx;
using Zenject;

namespace CodeBase.Abilities.Controllers
{
    public class AbilitySequence : IAbilitySequence
    {
        private readonly AbilityConfig _config;
        private readonly IInstantiator _instantiator;

        private readonly List<AbilityComponent> _sequence = new();
        
        public AbilitySequence(AbilityConfig config, IInstantiator instantiator)
        {
            _config = config;
            _instantiator = instantiator;
            
            ConstructSequence();
        }

        public IObservable<Unit> Play()
        {
            var abilitySequence = Observable.FromCoroutine(_sequence[0].PlayEffect);
            for (var index = 1; index < _sequence.Count; index++)
            {
                abilitySequence = abilitySequence.SelectMany(_sequence[index].PlayEffect);
            }

            abilitySequence = abilitySequence.DoOnCompleted(OnAbilityPlayed);
            
            return abilitySequence;
        }

        private void OnAbilityPlayed()
        {
            foreach (var abilityComponent in _sequence) 
                abilityComponent.OnEffectPlayed();
        }
        
        public void Dispose()
        {
            ClearSequence();
        }

        private void ConstructSequence()
        {
            var abilityComponentsData = _config
                .AbilityComponents
                .OrderBy(component => component.Priority);
            
            foreach (var abilityComponent in abilityComponentsData)
            {
                var type = Type.GetType(abilityComponent.ComponentType);

                if (type != null && typeof(AbilityComponent).IsAssignableFrom(type))
                {
                    var component = (AbilityComponent)_instantiator.Instantiate(type, new[] {abilityComponent});
                    _sequence.Add(component);
                }
            }
        }

        private void ClearSequence()
        {
            foreach (var abilityComponent in _sequence)
            {
                abilityComponent.Dispose();
            }
            
            _sequence.Clear();
        }
    }
}