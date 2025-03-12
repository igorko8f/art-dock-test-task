using CodeBase.Abilities.Enums;
using CodeBase.Components.EffectContainer;

namespace CodeBase.Components.Enemy
{
    public class EnemyEffectsContainer : EffectsContainer
    {
        private EnemyBase _enemyBase;
        
        public void Construct(EnemyBase holder)
        {
            _enemyBase = holder;
        }

        protected override void OnEntityPlayEffect(float value, AbilityDamageType damageType)
        {
            _enemyBase.Health.ApplyDamage(value, damageType);
        }
    }
}