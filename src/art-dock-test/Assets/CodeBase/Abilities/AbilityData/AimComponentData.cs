using CodeBase.Abilities.Enums;
using NaughtyAttributes;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class AimComponentData : AbilityComponentData
    {
        public AbilityAimType AimType;
        
        [ShowIf("AimType", AbilityAimType.Ange)] 
        [AllowNesting]
        public float Angle;
        public float RotationTime;
        
        public AbilityPlayTime PlayTime;
    }
}