using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Enemy;
using CodeBase.Components.Player;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class AimComponent : AbilityComponent
    {
        private readonly AimComponentData _data;
        private readonly IPlayerHolder _playerHolder;
        private readonly IEnemiesHolder _enemiesHolder;

        public AimComponent(AimComponentData data, IPlayerHolder playerHolder, IEnemiesHolder enemiesHolder)
        {
            _data = data;
            _playerHolder = playerHolder;
            _enemiesHolder = enemiesHolder;
        }
        
        public override IEnumerator PlayEffect()
        {
            if (_data.PlayTime.Type == AbilityPlayTimeType.Delay)
            {
                yield return new WaitForSeconds(_data.PlayTime.DelayTime);
            }
            
            if (_data.AimType == AbilityAimType.LockToTarget)
            {
                yield return HoldUntilIsNoValueInObservable(_enemiesHolder.SelectedEnemy);

                _enemiesHolder.SetPossibilityToSelectEnemy(false);
                yield return _playerHolder.Player.Movement
                    .RotateToTargetPosition(_enemiesHolder.SelectedEnemy.Value.GetPosition(), _data.RotationTime);
            }
            else
            {
                yield return _playerHolder.Player.Movement.RotateByAngle(_data.Angle, _data.RotationTime);
            }
            
            yield return base.PlayEffect();
        }

        public override void OnEffectPlayed()
        {
            _enemiesHolder.UnselectCurrentEnemy();
            _enemiesHolder.SetPossibilityToSelectEnemy(true);
        }
    }
}