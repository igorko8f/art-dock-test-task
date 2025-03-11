using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class FreezingComponent : AbilityComponent
    {
        private readonly FreezingComponentData _data;

        public FreezingComponent(FreezingComponentData data)
        {
            _data = data;
        }
    }
}