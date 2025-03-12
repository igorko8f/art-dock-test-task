using CodeBase.Abilities.Enums;

namespace CodeBase.Components.Health
{
    public interface IEntityHealth
    {
        float TotalHealth { get; }

        void EnableImmortality();
        void DisableImmortality();
        void Heal(float value);
        void ApplyDamage(float damage, AbilityDamageType damageType);
    }
}