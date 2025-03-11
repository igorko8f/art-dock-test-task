using System;
using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Services.InputService;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class LockInputComponent : AbilityComponent
    {
        private readonly LockInputComponentData _data;
        private readonly IInputService _inputService;

        public LockInputComponent(LockInputComponentData data, IInputService inputService)
        {
            _data = data;
            _inputService = inputService;
        }

        public override IEnumerator PlayEffect()
        {
            var playTimeType = _data.PlayTime.Type;

            switch (playTimeType)
            {
                case AbilityPlayTimeType.Delay:
                    yield return new WaitForSeconds(_data.PlayTime.DelayTime);
                    break;
                case AbilityPlayTimeType.AnimationLink:
                    break;
            }
            
            _inputService.DisableInput();
            
            yield return base.PlayEffect();
        }

        public override void OnEffectPlayed()
        {
            _inputService.EnableInput();
        }
    }
}