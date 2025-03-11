using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class VisualFXComponent : AbilityComponent
    {
        private readonly VisualFXComponentData _data;

        public VisualFXComponent(VisualFXComponentData data)
        {
            _data = data;
        }
    }
}