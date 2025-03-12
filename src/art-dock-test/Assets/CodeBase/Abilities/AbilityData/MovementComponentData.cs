using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Abilities.AbilityData
{
    [System.Serializable]
    public class MovementComponentData : AbilityComponentData
    {
        public Vector2 SetPosition;
        public float Time;
        
        public AbilityPlayTime PlayTime;
    }
}