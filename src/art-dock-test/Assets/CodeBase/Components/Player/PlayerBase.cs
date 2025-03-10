using System;
using CodeBase.Abilities;
using CodeBase.Abilities.Controllers;
using CodeBase.Components.Player.Abilities;
using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    public class PlayerBase : MonoBehaviour, IResource
    {
        [SerializeField] private PlayerAbilitiesBinder _playerAbilities;

        private AbilityController _abilityController;
        
        [Inject]
        public void Construct(IInstantiator instantiator)
        {
            _abilityController = new AbilityController(instantiator);
            _abilityController.ConstructAbilitySequences(_playerAbilities.GetAbilities());
        }

        public void OnEnable()
        {
            _playerAbilities.AbilityTriggered += OnAbilityTriggered;
        }

        public void OnDisable()
        {
            _playerAbilities.AbilityTriggered -= OnAbilityTriggered;
        }

        private void OnAbilityTriggered(AbilityConfig ability)
        {
            _abilityController.PlayAbility(ability);
        }
    }
}