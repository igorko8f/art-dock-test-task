using CodeBase.Abilities;
using CodeBase.Abilities.Controllers;
using CodeBase.Components.Animation;
using CodeBase.Components.EffectContainer;
using CodeBase.Components.Health;
using CodeBase.Components.Player.Abilities;
using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
    public class PlayerBase : MonoBehaviour, IResource, IAbilityTarget
    {
        public EntityAnimationController AnimationController => _animationController;
        public PlayerMovement Movement => _movement;
        public IEntityHealth Health => _playerHealth;
        public EffectsContainer EffectsContainer => _playerEffectsContainer;
        
        [SerializeField] private PlayerAbilitiesBinder _playerAbilities;
        [SerializeField] private EntityAnimationController _animationController;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private EntityHealth _playerHealth;
        [SerializeField] private PlayerEffectsContainer _playerEffectsContainer;

        private IAbilityController _abilityController;
        
        [Inject]
        public void Construct(IAbilityController abilityController)
        {
            _abilityController = abilityController;
            _playerEffectsContainer.Construct(this);
        }

        public void OnEnable()
        {
            _playerAbilities.AbilityTriggered += OnAbilityTriggered;
        }

        public void OnDisable()
        {
            _playerAbilities.AbilityTriggered -= OnAbilityTriggered;
        }

        public Vector3 GetPosition() => 
            transform.position;

        private void OnAbilityTriggered(AbilityConfig ability)
        {
            _abilityController.PlayAbility(ability);
        }
    }
}