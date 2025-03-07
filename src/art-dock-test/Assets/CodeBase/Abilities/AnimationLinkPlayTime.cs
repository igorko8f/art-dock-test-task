using CodeBase.Abilities.Enums;
using NaughtyAttributes;

namespace CodeBase.Abilities
{
    [System.Serializable]
    public struct AnimationLinkPlayTime
    {
        public string AnimationName;
        public AnimationLinkPlayTimeType PlayTimeType;

        [ShowIf("PlayTimeType", AnimationLinkPlayTimeType.Delay)]
        [AllowNesting]
        public float DelayTime;
    }
}