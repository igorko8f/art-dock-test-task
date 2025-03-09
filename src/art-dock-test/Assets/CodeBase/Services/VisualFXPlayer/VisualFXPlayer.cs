using System.Collections;
using System.Collections.Generic;
using CodeBase.Systems.CoroutineRunner;
using UnityEngine;

namespace CodeBase.Services.VisualFXPlayer
{
    public class VisualFXPlayer : IVisualFXPlayer
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public VisualFXPlayer(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void PlayEffectInstant(VisualFX effectPrefab, Vector3 position, float duration = 0)
        {
            var effect = InstallAndPLayEffect(effectPrefab, position);
            Object.Destroy(effect, effect.GetEffectDuration() + duration);
        }

        public void PlayEffectWithDelay(VisualFX effectPrefab, Vector3 position, float delay, float duration = 0)
        {
            _coroutineRunner.RunCoroutine(PlayWithDelay(effectPrefab, position, delay, duration));
        }

        private IEnumerator PlayWithDelay(VisualFX effectPrefab, Vector3 position, float delay, float duration = 0)
        {
            yield return new WaitForSeconds(delay);
            PlayEffectInstant(effectPrefab, position, duration);
        }
        
        private VisualFX InstallAndPLayEffect(VisualFX effectPrefab, Vector3 position)
        {
            effectPrefab.Initialize();
            
            var effect = Object.Instantiate(effectPrefab, position, Quaternion.identity);
            if (effect.AutomatLaunching() == false)
            {
                effect.PlayEffect();
            }

            return effect;
        }

        public void Dispose()
        {
            
        }
    }
}