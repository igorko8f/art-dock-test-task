using UnityEngine;
using Zenject;

namespace CodeBase.Services.AudioManager
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour, IAudioManager
    {
        private AudioSource _audioSource;

        [Inject]
        public void Construct()
        {
            name = "[AudioManager]";
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }

        public void SetMusicVolume(float volume)
        {
            _audioSource.volume = Mathf.Clamp01(volume);
        }

    }
}