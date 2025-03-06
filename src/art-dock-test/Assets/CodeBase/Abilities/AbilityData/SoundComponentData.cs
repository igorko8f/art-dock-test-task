using UnityEngine;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class SoundComponentData : AbilityComponentData
    {
        public AudioClip SoundFX;
        public AbilityPlayTime PlayTime;
    }
}