using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Components.Player;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class AnimationComponent : AbilityComponent
    {
        private readonly AnimationComponentData _data;
        private readonly IPlayerHolder _playerHolder;

        public AnimationComponent(AnimationComponentData data, IPlayerHolder playerHolder)
        {
            _data = data;
            _playerHolder = playerHolder;
        }

        public override IEnumerator PlayEffect()
        {
            var playerAnimationController = _playerHolder.Player.AnimationController;
            var animationTime = playerAnimationController.PlayAnimation(_data.AnimationToPlay);

            if (_data.WaitUntillEnd)
            {
                yield return new WaitForSeconds(animationTime);
            }

            yield return base.PlayEffect();
        }

        public override void OnEffectPlayed()
        {
            _playerHolder.Player.AnimationController.StopCurrentAnimation();
        }
    }
}