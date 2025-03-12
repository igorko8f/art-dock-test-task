using System.Collections.Generic;
using CodeBase.Abilities.Enums;
using UnityEngine;

namespace CodeBase.Components.EffectContainer
{
    public class EffectsContainer : MonoBehaviour
    {
        private List<EntityContinuousEffect> _effects = new();
        
        public void AddEffect(float duration, float delay, float value, AbilityDamageType damageType)
        {
            var effect = new EntityContinuousEffect(duration, delay, value, damageType, OnEntityPlayEffect, OnEntityEffectEnded);
            _effects.Add(effect);
        }

        protected virtual void OnEntityPlayEffect(float value, AbilityDamageType damageType)
        {
            
        }

        protected virtual void OnEntityEffectEnded(EntityContinuousEffect effect)
        {
            _effects.Remove(effect);
            effect.Dispose();
        }
    }
}