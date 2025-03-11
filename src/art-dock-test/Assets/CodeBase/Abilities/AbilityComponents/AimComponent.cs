using System.Collections;
using CodeBase.Abilities.AbilityData;

namespace CodeBase.Abilities.AbilityComponents
{
    public class AimComponent : AbilityComponent
    {
        private readonly AimComponentData _data;

        public AimComponent(AimComponentData data)
        {
            _data = data;
        }
        
        public override IEnumerator PlayEffect()
        {
            return base.PlayEffect();
        }
    }
}