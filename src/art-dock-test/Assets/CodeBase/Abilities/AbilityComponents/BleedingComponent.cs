using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class BleedingComponent : AbilityComponent
    {
        private readonly BleedingComponentData _data;

        public BleedingComponent(BleedingComponentData data)
        {
            _data = data;
        }
    }
}