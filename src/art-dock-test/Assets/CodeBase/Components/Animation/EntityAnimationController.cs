using System;
using UniRx;
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
        private IDisposable _currentAnimationTimer;

        [Inject]
        public void Construct()
        {
            if (_runtimeAnimator == null) 
                _runtimeAnimator = _animator.runtimeAnimatorController;
            
            _animator.Play(_defaultState);
        }
        
        public float PlayAnimation(string animationName, bool runDefaultAfterPLaying)
        {
            if (_isPlaying) 
                StopCurrentAnimation();

            _currentPlayingAnimation = animationName;
            _animator.Play(_currentPlayingAnimation);
            
            _isPlaying = true;
            
            if (runDefaultAfterPLaying)
                StopCurrentAnimation(true);
            
            return GetCurrentAnimationDuration();
        }

        public void StopCurrentAnimation(bool waitUntilEnd = false)
        {
            if (_isPlaying == false) 
                return;

            if (waitUntilEnd)
            {
                _currentAnimationTimer = Observable.Timer(TimeSpan.FromSeconds(GetCurrentAnimationDuration()))
                    .Subscribe((_) => StopAndSetDefaultAnimation())
                    .AddTo(this);
            }
            else
            {
                StopAndSetDefaultAnimation();
            }
        }

        private void StopAndSetDefaultAnimation()
        {
            _currentAnimationTimer?.Dispose();
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