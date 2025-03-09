using System;

namespace CodeBase.Components.Enemy
{
    public interface IEnemiesHolder : IDisposable
    {
        void SetEnemySelected(EnemyBase selectedEnemy);
        void UnselectCurrentEnemy();
    }
}