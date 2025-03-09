using System.Collections.Generic;
using CodeBase.Services.ProjectResourcesProvider;
using UnityEngine;

namespace CodeBase.Components.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemySpawnPoint[] _enemyStartSpawnPoints;
        private readonly EnemyBase _enemyPrefab;
        
        public EnemyFactory(IProjectResourcesProvider resourcesProvider)
        {
            //TODO: Collect enemy spawn points in config
            _enemyStartSpawnPoints = Object.FindObjectsByType<EnemySpawnPoint>(FindObjectsSortMode.None);
            _enemyPrefab = resourcesProvider.LoadResource<EnemyBase>();
        }
        
        public IEnumerable<EnemyBase> CreateStartupEnemies()
        {
            var result = new List<EnemyBase>();
            foreach (var spawnPoint in _enemyStartSpawnPoints)
            {
                var enemy = CreateEnemy(spawnPoint);
                result.Add(enemy);
            }

            return result;
        }

        public EnemyBase CreateEnemy(EnemySpawnPoint enemySpawnPoint)
        {
            return Object.Instantiate(_enemyPrefab, enemySpawnPoint.transform);
        }
    }
}