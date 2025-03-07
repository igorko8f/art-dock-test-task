using CodeBase.Abilities.Enums;
using NaughtyAttributes;

namespace CodeBase.Abilities
{
    [System.Serializable]
    public class AbilityPlayTime
    {
        public AbilityPlayTimeType Type;
        
        [ShowIf("Type", AbilityPlayTimeType.Delay)]
        [AllowNesting]
        public float DelayTime = 0f;
        
        [ShowIf("Type", AbilityPlayTimeType.AnimationLink)]
        [AllowNesting]
        public AnimationLinkPlayTime AnimationLinkPlayTime;
    }
}