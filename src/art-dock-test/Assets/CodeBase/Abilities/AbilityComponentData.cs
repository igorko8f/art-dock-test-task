using System;
using CodeBase.Abilities.Enums;
using UnityEngine;

namespace CodeBase.Abilities
{
    [System.Serializable]
    public class AbilityComponentData
    {
        [HideInInspector] public string Name;
        [HideInInspector] public string ComponentType;
        
        public AbilityPriority Priority;
    }
} 