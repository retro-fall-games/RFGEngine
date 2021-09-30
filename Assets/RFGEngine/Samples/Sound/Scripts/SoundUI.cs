using UnityEngine;
using UnityEngine.UI;
using RFG.Core;

public class SoundUI : MonoBehaviour
{
  public Slider SoundTrackSlider;
  public AudioMixerSettings SoundTrackAudioMixerSettings;
  public Slider AmbienceSlider;
  public AudioMixerSettings AmbienceAudioMixerSettings;
  public Slider EffectsSlider;
  public AudioMixerSettings EffectsAudioMixerSettings;

  private void Awake()
  {
    SoundTrackSlider.value = SoundTrackAudioMixerSettings.GetVolume();
    AmbienceSlider.value = AmbienceAudioMixerSettings.GetVolume();
    EffectsSlider.value = EffectsAudioMixerSettings.GetVolume();
  }
}
