using CodeBase.Components.EffectContainer;
using CodeBase.Components.Health;
using UnityEngine;

namespace CodeBase.Abilities
{
    public interface IAbilityTarget
    {
        IEntityHealth Health { get; }
        EffectsContainer EffectsContainer { get; }

        Vector3 GetPosition();
    }
}