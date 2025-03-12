using CodeBase.Abilities.Enums;
using CodeBase.Services.VisualFXPlayer;
using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class VisualFXComponentData : AbilityComponentData
    {
        public VisualFX EffectPrefab;
        public Vector3 PositionOffset;
        public AbilityTargetType TargetType;
        public AbilityEffectDurationType DurationType;

        [ShowIf("DurationType", AbilityEffectDurationType.Continuous)] 
        [AllowNesting]
        public float Duration;

        public AbilityPlayTime PlayTime;
    }
}