using CodeBase.Abilities;
using CodeBase.Components.EffectContainer;
using CodeBase.Components.Health;
using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Enemy
{
    public class EnemyBase : MonoBehaviour , IResource, IAbilityTarget
    {
        public IEntityHealth Health => _entityHealth;
        public EffectsContainer EffectsContainer => _effectsContainer;
        
        [SerializeField] private EnemySelector _selector;
        [SerializeField] private GameObject _selectorObject;
        [SerializeField] private EntityHealth _entityHealth;
        [SerializeField] private EnemyEffectsContainer _effectsContainer;
        
        private IEnemiesHolder _enemiesHolder;
        
        [Inject]
        public void Construct(IEnemiesHolder enemiesHolder)
        {
            _enemiesHolder = enemiesHolder;
            _effectsContainer.Construct(this);
        }

        private void OnEnable()
        {
            _selector.EnemySelected += OnEnemySelected;
        }

        private void OnDisable()
        {
            _selector.EnemySelected -= OnEnemySelected;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public float GetDistanceFrom(Vector3 position)
        {
            return Vector3.Distance(position, transform.position);
        }

        public void EnableVisualSelector()
        {
            _selectorObject.gameObject.SetActive(true);
        }
        
        public void DisableVisualSelector()
        {
            _selectorObject.gameObject.SetActive(false);
        }

        private void OnEnemySelected()
        {
            _enemiesHolder.SetEnemySelected(this);
        }
    }
}