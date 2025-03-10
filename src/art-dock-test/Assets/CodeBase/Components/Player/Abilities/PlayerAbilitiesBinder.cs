using System;
using System.Linq;
using CodeBase.Abilities;
using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player.Abilities
{
    public class PlayerAbilitiesBinder : MonoBehaviour
    {
        public event Action<AbilityConfig> AbilityTriggered;
        
        [SerializeField] 
        private AbilityBind[] _playerAbilitiesToUse;

        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public AbilityConfig[] GetAbilities()
        {
            return _playerAbilitiesToUse
                .Select(x => x.Ability)
                .ToArray();
        }

        public void Update()
        {
            for (int i = 0; i < _playerAbilitiesToUse.Length; i++)
                if (_inputService.ValidateInput(_playerAbilitiesToUse[i].HotKey)) 
                    AbilityTriggered?.Invoke(_playerAbilitiesToUse[i].Ability);
        }
    }
}