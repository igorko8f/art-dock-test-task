using CodeBase.Abilities.AbilityData;
using CodeBase.Abilities.Enums;
using CodeBase.Components.Enemy;
using CodeBase.Components.Player;
using CodeBase.Services.VisualFXPlayer;

namespace CodeBase.Abilities.AbilityComponents
{
    public class CombustionComponent : DamageComponent
    {
        public CombustionComponent(DamageComponentData data, IPlayerHolder playerHolder, IEnemiesHolder enemiesHolder, IVisualFXPlayer visualFXPlayer) : base(data, playerHolder, enemiesHolder, visualFXPlayer)
        {
            damageType = AbilityDamageType.Combustion;
        }
    }
}