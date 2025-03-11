using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class SlowDownComponent : AbilityComponent
    {
        private readonly SlowDownComponentData _data;

        public SlowDownComponent(SlowDownComponentData data)
        {
            _data = data;
        }
    }
}