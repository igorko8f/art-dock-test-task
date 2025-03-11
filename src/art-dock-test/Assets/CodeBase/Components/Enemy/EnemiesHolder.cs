using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace CodeBase.Components.Enemy
{
    public class EnemiesHolder : IEnemiesHolder
    {
        private readonly IEnemyFactory _factory;
        private readonly List<EnemyBase> _enemyList;

        public ReactiveProperty<EnemyBase> SelectedEnemy => _selectedEnemy;
        private ReactiveProperty<EnemyBase> _selectedEnemy = new ReactiveProperty<EnemyBase>();

        private bool _itIsPossibleToSelectEnemy = true;
        
        public EnemiesHolder(IEnemyFactory factory)
        {
            _factory = factory;
            _enemyList = _factory.CreateStartupEnemies().ToList();

            foreach (var enemyBase in _enemyList) 
                enemyBase.Construct(this);
        }

        public void SetEnemySelected(EnemyBase selectedEnemy)
        {
            if (_itIsPossibleToSelectEnemy == false) 
                return;
            
            if (_selectedEnemy.Value != null) 
                UnselectCurrentEnemy();

            _selectedEnemy.Value = selectedEnemy;
            _selectedEnemy.Value.EnableVisualSelector();
        }

        public IEnumerable<EnemyBase> GetEnemiesInRange(float range)
        {
            if (_selectedEnemy.Value == null)
            {
                Debug.LogWarning("There is no enemy selected!");
                return null;
            }
            
            var result = new List<EnemyBase>();
            foreach (var enemyBase in _enemyList)
            {
                if (enemyBase.GetDistanceFrom(_selectedEnemy.Value.GetPosition()) <= range) 
                    result.Add(enemyBase);
            }

            return result;
        }

        public void SetPossibilityToSelectEnemy(bool enabled) => 
            _itIsPossibleToSelectEnemy = enabled;

        public void UnselectCurrentEnemy()
        {
            _selectedEnemy.Value.DisableVisualSelector();
            _selectedEnemy.Value = null;
        }

        public void Dispose()
        {
            UnselectCurrentEnemy();
            _enemyList.Clear();
        }
    }
}