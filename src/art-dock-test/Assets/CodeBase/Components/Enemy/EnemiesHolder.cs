using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Components.Enemy
{
    public class EnemiesHolder : IEnemiesHolder
    {
        private readonly IEnemyFactory _factory;
        private readonly List<EnemyBase> _enemyList;

        private EnemyBase _selectedEnemy;
        
        public EnemiesHolder(IEnemyFactory factory)
        {
            _factory = factory;
            _enemyList = _factory.CreateStartupEnemies().ToList();
        }

        public void SetEnemySelected(EnemyBase selectedEnemy)
        {
            if (_selectedEnemy != null) 
                UnselectCurrentEnemy();

            _selectedEnemy = selectedEnemy;
        }

        public EnemyBase GetSelectedEnemy()
        {
            if (_selectedEnemy == null) 
                Debug.LogWarning("There is no enemy selected!");
            
            return _selectedEnemy;
        }

        public IEnumerable<EnemyBase> GetEnemiesInRange(float range)
        {
            if (_selectedEnemy == null)
            {
                Debug.LogWarning("There is no enemy selected!");
                return null;
            }
            
            var result = new List<EnemyBase>();
            foreach (var enemyBase in _enemyList)
            {
                if (enemyBase.GetDistanceFrom(_selectedEnemy.GetPosition()) <= range) 
                    result.Add(enemyBase);
            }

            return result;
        }

        public void UnselectCurrentEnemy()
        {
            _selectedEnemy = null;
        }

        public void Dispose()
        {
            UnselectCurrentEnemy();
            _enemyList.Clear();
        }
    }
}