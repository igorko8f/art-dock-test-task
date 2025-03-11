using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Enemy
{
    public class EnemyBase : MonoBehaviour , IResource
    {
        [SerializeField] private EnemySelector _selector;
        [SerializeField] private GameObject _selectorObject;
        
        private IEnemiesHolder _enemiesHolder;
        
        [Inject]
        public void Construct(IEnemiesHolder enemiesHolder)
        {
            _enemiesHolder = enemiesHolder;
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