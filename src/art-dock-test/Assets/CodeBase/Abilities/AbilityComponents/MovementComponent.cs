using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Player;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class MovementComponent : AbilityComponent
    {
        private readonly MovementComponentData _data;
        private readonly IPlayerHolder _playerHolder;

        public MovementComponent(MovementComponentData data, IPlayerHolder playerHolder)
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

            yield return _playerHolder.Player.Movement.SetPositionOffset(_data.SetPosition, _data.Time);
            
            yield return base.PlayEffect();
        }
    }
}