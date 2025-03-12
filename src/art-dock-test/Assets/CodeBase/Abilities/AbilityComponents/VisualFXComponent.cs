using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Enemy;
using CodeBase.Components.Player;
using CodeBase.Services.VisualFXPlayer;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class VisualFXComponent : AbilityComponent
    {
        private readonly VisualFXComponentData _data;
        private readonly IVisualFXPlayer _visualFXPlayer;
        private readonly IPlayerHolder _playerHolder;
        private readonly IEnemiesHolder _enemiesHolder;

        public VisualFXComponent(VisualFXComponentData data, 
            IVisualFXPlayer visualFXPlayer, 
            IPlayerHolder playerHolder,
            IEnemiesHolder enemiesHolder)
        {
            _data = data;
            _visualFXPlayer = visualFXPlayer;
            _playerHolder = playerHolder;
            _enemiesHolder = enemiesHolder;
        }

        public override IEnumerator PlayEffect()
        {
            if (_data.PlayTime.Type == AbilityPlayTimeType.Delay)
            {
                yield return new WaitForSeconds(_data.PlayTime.DelayTime);
            }
            
            if (_data.TargetType == AbilityTargetType.Player)
            {
                var targetPosition = _playerHolder.Player.GetPosition() + _data.PositionOffset;
                _visualFXPlayer.PlayEffectInstant(_data.EffectPrefab, targetPosition, 
                    _data.DurationType  == AbilityEffectDurationType.Instant ? 0 : _data.Duration);
            }
            else
            {
                yield return HoldUntilIsNoValueInObservable(_enemiesHolder.SelectedEnemy);

                var targetPosition = _enemiesHolder.SelectedEnemy.Value.GetPosition() + _data.PositionOffset;
                
                _enemiesHolder.SetPossibilityToSelectEnemy(false);
                _visualFXPlayer.PlayEffectInstant(_data.EffectPrefab, targetPosition,
                    _data.DurationType  == AbilityEffectDurationType.Instant ? 0 : _data.Duration);
            }
            
            yield return base.PlayEffect();
        }

        public override void OnEffectPlayed()
        {
            _enemiesHolder.SetPossibilityToSelectEnemy(true);
        }
    }
}