using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Abilities
{
    [CreateAssetMenu(menuName = "AbilitySystem/Ability", fileName = "Ability")]
    public class AbilityConfig : ScriptableObject
    {
        [SerializeReference]
        public List<AbilityComponentData> _abilityComponents = new();

#if UNITY_EDITOR
        //Possibility to add component in Unity Inspector
        
        [Dropdown("GetAbilityTypeValues")]
        public string _selectedAbility;

        private Dictionary<string, string> _typeCache = new();
        
        public void OnEnable()
        {
            UpdateAbilityTypesCache();
        }

        [Button]
        private void AddComponent()
        {
            var abilityType = Type.GetType(_selectedAbility);
            
            if (abilityType != null && typeof(AbilityComponentData).IsAssignableFrom(abilityType))
            {
                var ability = (AbilityComponentData)Activator.CreateInstance(abilityType);
                ability.Name = ability.GetType().Name;
                _abilityComponents.Add(ability);
                Debug.Log($"Added ability: {ability.GetType().Name}");
            }
            else
            {
                Debug.Log($"Cannot add ability: {abilityType} , type is empty or is not assignable from AbilityComponentData");
            }
        }
        
        private DropdownList<string> GetAbilityTypeValues()
        {
            if (_typeCache == null || _typeCache.Any() == false)
            {
                UpdateAbilityTypesCache();
            }
            
            var abilityDataInfo = new DropdownList<string>();

            foreach (var t in _typeCache)
                abilityDataInfo.Add(t.Key, t.Value);

            return abilityDataInfo;
        }

        private void UpdateAbilityTypesCache()
        {
            _typeCache.Clear();
            _typeCache = GetAllAbilityDataTypes();
        }
        
        private Dictionary<string, string> GetAllAbilityDataTypes()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => t.Namespace == "CodeBase.Abilities.AbilityData" && t.IsClass)
                .ToDictionary(t => t.Name, t => t.AssemblyQualifiedName);
        }
#endif
        
    }
}