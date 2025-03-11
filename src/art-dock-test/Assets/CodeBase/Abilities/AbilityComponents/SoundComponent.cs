using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class SoundComponent : AbilityComponent
    {
        private readonly SoundComponentData _data;

        public SoundComponent(SoundComponentData data)
        {
            _data = data;
        }
    }
}