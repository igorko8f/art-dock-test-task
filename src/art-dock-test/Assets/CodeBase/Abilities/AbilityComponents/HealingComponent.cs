using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class HealingComponent : AbilityComponent
    {
        private readonly HealingComponentData _data;

        public HealingComponent(HealingComponentData data)
        {
            _data = data;
        }
    }
}