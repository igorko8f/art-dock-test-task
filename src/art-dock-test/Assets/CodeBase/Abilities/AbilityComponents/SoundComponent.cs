using System.Collections;
using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Services.AudioManager;
using UnityEngine;

namespace CodeBase.Abilities.AbilityComponents
{
    public class SoundComponent : AbilityComponent
    {
        private readonly SoundComponentData _data;
        private readonly IAudioManager _audioManager;

        public SoundComponent(SoundComponentData data, IAudioManager audioManager)
        {
            _data = data;
            _audioManager = audioManager;
        }

        public override IEnumerator PlayEffect()
        {
            if (_data.PlayTime.Type == AbilityPlayTimeType.Delay)
            {
                yield return new WaitForSeconds(_data.PlayTime.DelayTime);
            }
            
            _audioManager.PlaySound(_data.SoundFX);
            
            yield return base.PlayEffect();
        }
    }
}