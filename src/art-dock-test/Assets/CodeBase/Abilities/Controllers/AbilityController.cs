using System.Collections.Generic;
using Zenject;

namespace CodeBase.Abilities.Controllers
{
    public class AbilityController : IAbilityController
    {
        private readonly IInstantiator _instantiator;
        private readonly Dictionary<AbilityConfig, AbilitySequence> _abilitySequences = new();
        
        public AbilityController(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        public void ConstructAbilitySequences(AbilityConfig[] configs)
        {
            ClearAbilities();
            
            foreach (var abilityConfig in configs)
            {
                var sequence = _instantiator.Instantiate<AbilitySequence>(new[] { abilityConfig });
                _abilitySequences[abilityConfig] = sequence;
            }
        }

        private void ClearAbilities()
        {
            foreach (var abilitySequence in _abilitySequences) 
                abilitySequence.Value.Dispose();
            
            _abilitySequences.Clear();
        }
    }
}