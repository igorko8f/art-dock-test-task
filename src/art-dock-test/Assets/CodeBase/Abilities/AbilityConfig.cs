using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace CodeBase.Abilities
{
    [CreateAssetMenu(menuName = "AbilitySystem/Ability", fileName = "Ability")]
    public class AbilityConfig : ScriptableObject
    {
        public List<AbilityComponentData> AbilityComponents => _abilityComponents;
        
        //TODO: Make private , edit throw editor
        [SerializeReference]
        public List<AbilityComponentData> _abilityComponents = new();

#if UNITY_EDITOR
        //Possibility to add component in Unity Inspector
        
        [Dropdown("GetAbilityTypeValues")]
        public string _selectedAbility;

        private Dictionary<string, string> _dataTypeCache = new();
        private Dictionary<string, string> _componentTypeCache = new();
        private Dictionary<string, string> _dataToComponentReference = new();
        
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
                ability.ComponentType = _dataToComponentReference[_selectedAbility];
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
            if (_dataTypeCache == null || _dataTypeCache.Any() == false )
            {
                UpdateAbilityTypesCache();
            }
            
            
            var abilityDataInfo = new DropdownList<string>();

            _dataToComponentReference.Clear();
            foreach (var t in _dataTypeCache)
            {
                if (_componentTypeCache.ContainsKey(t.Key) == false) continue;
                
                abilityDataInfo.Add(t.Key, t.Value);
                _dataToComponentReference[t.Value] = _componentTypeCache[t.Key];
            }

            return abilityDataInfo;
        }

        private void UpdateAbilityTypesCache()
        {
            _dataToComponentReference.Clear();
            
            _dataTypeCache.Clear();
            _dataTypeCache = GetAllAbilityDataTypes();
            
            _componentTypeCache.Clear();
            _componentTypeCache = GetAllAbilityComponentTypes();
        }

        private Dictionary<string,string> GetAllAbilityComponentTypes()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => t.Namespace == "CodeBase.Abilities.AbilityComponents" 
                            && t.IsClass 
                            && !t.IsAbstract 
                            && !typeof(IEnumerator).IsAssignableFrom(t)
                            && t.Name != "AbilityComponent")
                .ToDictionary(t => t.Name, t => t.AssemblyQualifiedName);
        }

        private Dictionary<string, string> GetAllAbilityDataTypes()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => t.Namespace == "CodeBase.Abilities.AbilityData" && t.IsClass)
                .ToDictionary(t => t.Name.Replace("Data", ""), t => t.AssemblyQualifiedName);
        }
#endif
        
    }
}