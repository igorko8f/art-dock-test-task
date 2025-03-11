using System;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Animation
{
    public class EntityAnimationController : MonoBehaviour
    {
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
        
        public float PlayAnimation(string animationName)
        {
            if (_isPlaying) 
                StopCurrentAnimation();

            _currentPlayingAnimation = animationName;
            _animator.Play(_currentPlayingAnimation);
            
            _isPlaying = true;
            return GetCurrentAnimationDuration();
        }

        public void StopCurrentAnimation()
        {
            if (_isPlaying == false) 
                return;
            
            _isPlaying = false;
            _animator.Play(_defaultState);
            
            _currentPlayingAnimation = string.Empty;
        }

        public void SetFloatProperty(string name, float value)
        {
            _animator.SetFloat(name, value);
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