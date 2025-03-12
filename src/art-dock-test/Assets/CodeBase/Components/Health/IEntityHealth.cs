using CodeBase.Abilities.Enums;

namespace CodeBase.Components.Health
{
    public interface IEntityHealth
    {
        float TotalHealth { get; }

        void EnableImmortality();
        void DisableImmortality();
        void ApplyDamage(float damage, AbilityDamageType damageType);
    }
}