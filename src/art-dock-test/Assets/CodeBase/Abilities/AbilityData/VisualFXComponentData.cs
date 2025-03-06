using CodeBase.Services.VisualFXPlayer;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class VisualFXComponentData : AnimationComponentData
    {
        public VisualFX EffectPrefab;
        public AbilityPlayTime PlayTime;
    }
}