using CodeBase.Abilities.Enums;
using UnityEngine;

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
        
        public void Awake()
        {
            _health = _healthBaseValue;
            _defence = _defenceBaseValue;
            _isDead = false;
            _isImmortal = false;
        }

        public void Heal(float value)
        {
            if (_isDead)
            {
                Debug.Log($"Entity {gameObject.name} already died!");
                return;
            }

            if (_health >= _healthBaseValue)
            {
                Debug.Log($"Entity {gameObject.name} reached maximum of health!");
                return;
            }

            _health = Mathf.Clamp(_health + value, 0, _healthBaseValue);
            Debug.Log($"Entity {gameObject.name} healed by {_health} points!");
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
            
            Debug.Log($"Entity {gameObject.name} applied damage type - {damageType} - value {damage} DMG");
            Debug.Log($"Current health {_health}, current defence {_defence}");
        }
        
        public void EnableImmortality()
        {
            _isImmortal = true;
            Debug.Log($"Entity {gameObject.name} is immortal!");
        }

        public void DisableImmortality()
        {
            _isImmortal = false;
            Debug.Log($"Entity {gameObject.name} is not immortal anymore!");
        }
    }
}