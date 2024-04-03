using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    public void ToggleSound()
    {
        float volume = 0;
        _audioMixerGroup.audioMixer.GetFloat("MasterVolume", out volume);

        if (volume == 0)
        {
            _audioMixerGroup.audioMixer.SetFloat("MasterVolume", -80);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat("MasterVolume", 0);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeEffectsVolume(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
    }
}
