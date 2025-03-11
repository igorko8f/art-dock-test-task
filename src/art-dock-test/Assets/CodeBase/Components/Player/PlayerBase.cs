using CodeBase.Abilities;
using CodeBase.Abilities.Controllers;
using CodeBase.Components.Animation;
using CodeBase.Components.Player.Abilities;
using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    public class PlayerBase : MonoBehaviour, IResource
    {
        public EntityAnimationController AnimationController => _animationController;
        
        [SerializeField] private PlayerAbilitiesBinder _playerAbilities;
        [SerializeField] private EntityAnimationController _animationController;

        private IAbilityController _abilityController;
        
        [Inject]
        public void Construct(IAbilityController abilityController)
        {
            _abilityController = abilityController;
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