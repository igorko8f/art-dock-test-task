using CodeBase.Abilities.Enums;
using CodeBase.Services.VisualFXPlayer;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class VisualFXComponentData : AbilityComponentData
    {
        public VisualFX EffectPrefab;
        public AbilityTargetType TargetType;
        public AbilityPlayTime PlayTime;
    }
}