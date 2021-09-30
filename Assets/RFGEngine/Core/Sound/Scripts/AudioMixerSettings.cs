using System;
using UnityEngine;
using UnityEngine.Audio;

namespace RFG.Core
{
  [CreateAssetMenu(fileName = "New Audio Mixer Settings", menuName = "RFG/Core/Sound/Audio Mixer Settings")]
  public class AudioMixerSettings : ScriptableObject
  {
    public AudioMixer AudioMixer;
    public float FadeTime = 1f;
    public float Volume = 1f;

    public void Initialize()
    {
      SetVolume(Volume);
    }

    public void SetVolume(float volume)
    {
      if (volume < 0.001f)
      {
        volume = 0.001f;
      }
      Volume = volume;
      AudioMixer.SetFloat("Volume", Mathf.Log(Volume) * 20);
    }

    public float GetVolume()
    {
      return Volume;
    }
  }
}