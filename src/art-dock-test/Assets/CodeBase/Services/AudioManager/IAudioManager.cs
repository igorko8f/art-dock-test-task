using UnityEngine;

namespace CodeBase.Services.AudioManager
{
    public interface IAudioManager
    {
        void PlaySound(AudioClip audioClip);
        void SetMusicVolume(float volume);
    }
}