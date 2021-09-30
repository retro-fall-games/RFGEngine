using System.Collections.Generic;
using UnityEngine;

namespace RFG.Core
{
  [AddComponentMenu("RFG/Core/Sound/Sound Manager")]
  public class SoundManager : Singleton<SoundManager>
  {
    public List<AudioMixerSettings> AudioMixerSettings;

    private void Start()
    {
      foreach (AudioMixerSettings settings in AudioMixerSettings)
      {
        settings.Initialize();
      }
    }
  }
}