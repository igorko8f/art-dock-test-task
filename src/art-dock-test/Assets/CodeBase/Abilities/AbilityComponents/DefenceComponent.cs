using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class DefenceComponent : AbilityComponent
    {
        private readonly DefenceComponentData _data;

        public DefenceComponent(DefenceComponentData data)
        {
            _data = data;
        }
    }
}