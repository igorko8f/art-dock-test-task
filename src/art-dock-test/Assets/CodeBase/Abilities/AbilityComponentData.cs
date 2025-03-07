using System;
using CodeBase.Abilities.Enums;
using UnityEngine;

namespace CodeBase.Abilities
{
    [System.Serializable]
    public class AbilityComponentData
    {
        [HideInInspector] public string Name;
        public Type ComponentType;
        
        public AbilityPriority Priority;
    }
}