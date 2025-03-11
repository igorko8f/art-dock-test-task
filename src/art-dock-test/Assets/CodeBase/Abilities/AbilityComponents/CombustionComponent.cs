using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class CombustionComponent : AbilityComponent
    {
        private readonly CombustionComponentData _data;

        public CombustionComponent(CombustionComponentData data)
        {
            _data = data;
        }
    }
}