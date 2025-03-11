using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class MovementComponent : AbilityComponent
    {
        private readonly MovementComponentData _data;

        public MovementComponent(MovementComponentData data)
        {
            _data = data;
        }
    }
}