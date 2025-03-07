using System.Collections.Generic;
using System.Linq;
using CodeBase.Abilities.AbilityComponents;
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

        public void Play()
        {
            foreach (var component in _sequence) 
                component.PlayEffect();
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
                var component = (AbilityComponent)_instantiator.Instantiate(abilityComponent.ComponentType, new[] {abilityComponent});
                _sequence.Add(component);
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