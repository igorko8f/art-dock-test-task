using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class DamageComponent : AbilityComponent
    {
        private readonly DamageComponentData _data;

        public DamageComponent(DamageComponentData data)
        {
            _data = data;
        }
    }
}