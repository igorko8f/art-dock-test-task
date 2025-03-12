using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Player;
using CodeBase.Services.VisualFXPlayer;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class HealingComponent : AbilityComponent
    {
        private readonly HealingComponentData _data;
        private readonly IVisualFXPlayer _visualFXPlayer;
        private readonly IPlayerHolder _playerHolder;

        public HealingComponent(HealingComponentData data, IVisualFXPlayer visualFXPlayer, IPlayerHolder playerHolder)
        {
            _data = data;
            _visualFXPlayer = visualFXPlayer;
            _playerHolder = playerHolder;
        }

        public override IEnumerator PlayEffect()
        {
            if (_data.PlayTime.Type == AbilityPlayTimeType.Delay)
            {
                yield return new WaitForSeconds(_data.Delay);
            }
            
            if (_data.AdditionalFXPrefab != null)
            {
                _visualFXPlayer.PlayEffectInstant(_data.AdditionalFXPrefab, _playerHolder.Player.GetPosition(), 
                    _data.DurationType == AbilityEffectDurationType.Instant ? 0 : _data.Duration, _playerHolder.Player.GetTarget());
            }

            if (_data.DurationType == AbilityEffectDurationType.Instant)
            {
                _playerHolder.Player.Health.Heal(_data.Value);
            }
            else
            {
                _playerHolder.Player.EffectsContainer.AddEffect(_data.Duration, _data.Delay, _data.Value, AbilityDamageType.Healing);
            }

            yield return base.PlayEffect();
        }
    }
}