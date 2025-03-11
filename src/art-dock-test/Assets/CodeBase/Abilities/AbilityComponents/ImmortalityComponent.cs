using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class ImmortalityComponent : AbilityComponent
    {
        private readonly ImmortalityComponentData _data;

        public ImmortalityComponent(ImmortalityComponentData data)
        {
            _data = data;
        }
    }
}