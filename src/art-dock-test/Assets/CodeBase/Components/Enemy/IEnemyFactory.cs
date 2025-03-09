using System.Collections.Generic;

namespace CodeBase.Components.Enemy
{
    public interface IEnemyFactory
    {
        IEnumerable<EnemyBase> CreateStartupEnemies();
        EnemyBase CreateEnemy(EnemySpawnPoint enemySpawnPoint);
    }
}