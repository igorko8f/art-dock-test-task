using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Animation
{
    public class EntityAnimationController : MonoBehaviour
    {
        public event Action<string> AnimationStarted;
        public event Action<string> AnimationCompleted;

        [SerializeField] private Animator _animator;
        [SerializeField] private string _defaultState = "Idle";

        private RuntimeAnimatorController _runtimeAnimator;
        
        private string _currentPlayingAnimation;
        private bool _isPlaying = false;

        [Inject]
        public void Construct()
        {
            if (_runtimeAnimator == null) 
                _runtimeAnimator = _animator.runtimeAnimatorController;
            
            _animator.Play(_defaultState);
        }
        
        public void PlayAnimation(string animationName)
        {
            if (_isPlaying) 
                StopCurrentAnimation();

            _currentPlayingAnimation = animationName;
            _animator.Play(_currentPlayingAnimation);
            
            AnimationStarted?.Invoke(_currentPlayingAnimation);
            _isPlaying = true;
        }

        public void SetFloatProperty(string name, float value)
        {
            _animator.SetFloat(name, value);
        }
        
        public void StopCurrentAnimation()
        {
            if (_isPlaying == false) 
                return;
            
            _isPlaying = false;
            _animator.Play(_defaultState);
            
            AnimationCompleted?.Invoke(_currentPlayingAnimation);
            _currentPlayingAnimation = string.Empty;
        }
        
        public float GetCurrentAnimationDuration()
        {
            if (_runtimeAnimator == null) return 0f;

            foreach (AnimationClip clip in _runtimeAnimator.animationClips)
            {
                if (clip.name == _currentPlayingAnimation)
                    return clip.length;
            }

            return 0f;
        }
    }
}