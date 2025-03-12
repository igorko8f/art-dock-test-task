using CodeBase.Abilities.Enums;
using CodeBase.Components.EffectContainer;

namespace CodeBase.Components.Player
{
    public class PlayerEffectsContainer : EffectsContainer
    {
        private PlayerBase _playerBase;
        
        public void Construct(PlayerBase playerBase)
        {
            _playerBase = playerBase;
        }

        protected override void OnEntityPlayEffect(float value, AbilityDamageType damageType)
        {
            if (damageType == AbilityDamageType.Healing)
            {
                _playerBase.Health.Heal(value);    
                return;
            }
            
            _playerBase.Health.ApplyDamage(value, damageType);
        }
    }
}