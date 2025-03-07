using CodeBase.Abilities.Enums;
using CodeBase.Services.VisualFXPlayer;
using NaughtyAttributes;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class DefenceComponentData : AbilityComponentData
    {
        public AbilityEffectDurationType DurationType;
        
        [ShowIf("DurationType", AbilityEffectDurationType.Continuous)]
        [AllowNesting]
        public float Duration;
        
        [ShowIf("DurationType", AbilityEffectDurationType.Continuous)]
        [AllowNesting]
        public float Delay;

        public float Value;
        
        public VisualFX AdditionalFXPrefab;
        
        public AbilityPlayTime PlayTime;
    }
}