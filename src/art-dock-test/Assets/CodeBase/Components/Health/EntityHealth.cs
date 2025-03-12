using CodeBase.Abilities.Enums;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Health
{
    public class EntityHealth : MonoBehaviour, IEntityHealth
    {
        public float TotalHealth => _defence + _health;

        [SerializeField] private float _healthBaseValue;
        [SerializeField] private float _defenceBaseValue;

        private float _health;
        private float _defence;
        
        private bool _isDead;
        private bool _isImmortal;

        [Inject]
        public void Construct()
        {
            _health = _healthBaseValue;
            _defence = _defenceBaseValue;
        }

        public void ApplyDamage(float damage, AbilityDamageType damageType)
        {
            if (_isDead)
            {
                Debug.Log($"Entity {gameObject.name} already died!");
                return;
            }

            if (_isImmortal)
            {
                Debug.Log($"Entity {gameObject.name} is immortal!");
                return;
            }

            _defence -= damage;
            if (_defence <= 0)
            {
                _health += _defence;
                _defence = 0;
            }

            if (_health <= 0)
            {
                _health = 0;
                _isDead = true;
            }
            
            Debug.Log($"Entity {gameObject.name} applied {damageType} - {damage} DMG");
            Debug.Log($"Current health {_health}, current defence {_defence}");
        }
        
        public void EnableImmortality()
        {
            _isImmortal = true;
        }

        public void DisableImmortality()
        {
            _isImmortal = false;
        }
    }
}