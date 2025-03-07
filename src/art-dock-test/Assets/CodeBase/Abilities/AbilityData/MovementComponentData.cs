using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class MovementComponentData : AbilityComponentData
    {
        public Vector2 SetPosition;
        public bool Animated;

        [ShowIf("Animated")] 
        [AllowNesting]
        public float AnimationSpeed;
        
        public AbilityPlayTime PlayTime;
    }
}