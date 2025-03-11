using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Abilities.Controllers
{
    public class AbilityController : IAbilityController
    {
        private readonly IInstantiator _instantiator;
        private readonly Dictionary<AbilityConfig, AbilitySequence> _abilitySequences = new();

        private IObservable<Unit> _currentPlayingAbility = new Subject<Unit>();
        private bool _isAnyAbilityPlaing = false;
        
        public AbilityController(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void PlayAbility(AbilityConfig config)
        {
            if (_isAnyAbilityPlaing)
            {
                Debug.Log($"Ability currently playing!");
                return;
            }
            
            if (_abilitySequences.TryGetValue(config, out var sequence))
            {
                _isAnyAbilityPlaing = true;
                _currentPlayingAbility = sequence.Play();
                _currentPlayingAbility
                    .DoOnCompleted(OnAbilityPlayed)
                    .Subscribe();
            }
            else
            {
                Debug.Log($"There is no sequence {config.name} for play ability");
            }
        }

        public void OnAbilityPlayed()
        {
            _isAnyAbilityPlaing = false;
            _currentPlayingAbility = null;
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

        public void Dispose()
        {
            ClearAbilities();
            _currentPlayingAbility = null;
        }
    }
}