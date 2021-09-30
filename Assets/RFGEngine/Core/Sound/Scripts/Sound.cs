using UnityEngine;

namespace RFG.Core
{
  [AddComponentMenu("RFG/Core/Sound/Sound")]
  public class Sound : MonoBehaviour
  {
    [field: SerializeField] public SoundData SoundData { get; set; }

    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
      if (_audioSource == null)
        return;

      _audioSource.Play();
    }

    public void Stop()
    {
      if (_audioSource == null)
        return;

      if (SoundData.FadeTime > 0f)
      {
        StartCoroutine(_audioSource.FadeOut(SoundData.FadeTime));
      }
      else
      {
        _audioSource.Stop();
      }
    }
  }
}