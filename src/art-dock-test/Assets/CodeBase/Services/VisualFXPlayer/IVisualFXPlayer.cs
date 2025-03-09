using System;
using UnityEngine;

namespace CodeBase.Services.VisualFXPlayer
{
    public interface IVisualFXPlayer : IDisposable
    {
        void PlayEffectInstant(VisualFX effectPrefab, Vector3 position, float duration = 0);
        void PlayEffectWithDelay(VisualFX effectPrefab, Vector3 position, float delay, float duration = 0);
    }
}