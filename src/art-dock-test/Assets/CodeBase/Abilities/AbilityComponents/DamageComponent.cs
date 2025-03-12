using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Enemy;
using CodeBase.Components.Player;
using CodeBase.Services.VisualFXPlayer;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class DamageComponent : AbilityComponent
    {
        protected AbilityDamageType damageType = AbilityDamageType.Simple;
        
        private readonly DamageComponentData _data;
        private readonly IPlayerHolder _playerHolder;
        private readonly IEnemiesHolder _enemiesHolder;
        private readonly IVisualFXPlayer _visualFXPlayer;

        public DamageComponent(DamageComponentData data, 
            IPlayerHolder playerHolder, 
            IEnemiesHolder enemiesHolder,
            IVisualFXPlayer visualFXPlayer)
        {
            _data = data;
            _playerHolder = playerHolder;
            _enemiesHolder = enemiesHolder;
            _visualFXPlayer = visualFXPlayer;
        }

        public override IEnumerator PlayEffect()
        {
            if (_data.PlayTime.Type == AbilityPlayTimeType.Delay)
            {
                yield return new WaitForSeconds(_data.PlayTime.DelayTime);
            }

            if (_data.TargetType == AbilityTargetType.Player)
            {
                ApplyEffectToTarget(_playerHolder.Player);
            }
            else
            {
                yield return HoldUntilIsNoValueInObservable(_enemiesHolder.SelectedEnemy);
                _enemiesHolder.SetPossibilityToSelectEnemy(false);

                if (_data.RangeType == AbilityEffectRangeType.Ranged)
                {
                    foreach (var enemy in _enemiesHolder.GetEnemiesInRange(_data.Range))
                    {
                        ApplyEffectToTarget(enemy);
                    }
                }
                else
                {
                    ApplyEffectToTarget(_enemiesHolder.SelectedEnemy.Value);
                }
            }

            yield return base.PlayEffect();
        }

        private void ApplyEffectToTarget(IAbilityTarget target)
        {
            if (_data.AdditionalFXPrefab != null)
            {
                _visualFXPlayer.PlayEffectInstant(_data.AdditionalFXPrefab, target.GetPosition(), _data.DurationType == AbilityEffectDurationType.Instant ? 0 : _data.Duration);
            }

            if (_data.DurationType == AbilityEffectDurationType.Instant)
            {
                target.Health.ApplyDamage(_data.Value, damageType);
            }
            else
            {
                target.EffectsContainer.AddEffect(_data.Duration, _data.Delay, _data.Value, damageType);
            }
        }
        
        public override void OnEffectPlayed()
        {
            _enemiesHolder.SetPossibilityToSelectEnemy(true);
        }
    }
}