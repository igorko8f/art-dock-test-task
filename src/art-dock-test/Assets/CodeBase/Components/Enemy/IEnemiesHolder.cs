﻿using System;
using System.Collections.Generic;
using UniRx;

namespace CodeBase.Components.Enemy
{
    public interface IEnemiesHolder : IDisposable
    {
        ReactiveProperty<EnemyBase> SelectedEnemy { get; }
        void SetEnemySelected(EnemyBase selectedEnemy);
        void UnselectCurrentEnemy();
        void SetPossibilityToSelectEnemy(bool enabled);
        IEnumerable<EnemyBase> GetEnemiesInRange(float range);
    }
}