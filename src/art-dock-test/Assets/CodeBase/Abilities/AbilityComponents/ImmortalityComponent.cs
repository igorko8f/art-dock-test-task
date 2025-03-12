using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Player;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class ImmortalityComponent : AbilityComponent
    {
        private readonly ImmortalityComponentData _data;
        private readonly IPlayerHolder _playerHolder;

        public ImmortalityComponent(ImmortalityComponentData data, IPlayerHolder playerHolder)
        {
            _data = data;
            _playerHolder = playerHolder;
        }

        public override IEnumerator PlayEffect()
        {
            if (_data.PlayTime.Type == AbilityPlayTimeType.Delay)
            {
                yield return new WaitForSeconds(_data.PlayTime.DelayTime);
            }
            
            _playerHolder.Player.Health.EnableImmortality();
            yield return base.PlayEffect();
        }

        public override void OnEffectPlayed()
        {
            _playerHolder.Player.Health.DisableImmortality();
        }
    }
}