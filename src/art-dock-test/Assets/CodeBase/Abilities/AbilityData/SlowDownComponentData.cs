using CodeBase.Abilities.Enums;
using NaughtyAttributes;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class SlowDownComponentData : AbilityComponentData
    {
        public AbilityTargetType TargetType;
        public AbilityEffectRangeType RangeType;

        [ShowIf("RangeType", AbilityEffectRangeType.Ranged)]
        [AllowNesting]
        public float Range;

        public AbilityEffectDurationType DurationType;
        
        [ShowIf("DurationType", AbilityEffectDurationType.Continuous)]
        [AllowNesting]
        public float Duration;
        
        [ShowIf("DurationType", AbilityEffectDurationType.Continuous)]
        [AllowNesting]
        public float Delay;

        public float Value;
        
        public AbilityPlayTime PlayTime;
    }
}