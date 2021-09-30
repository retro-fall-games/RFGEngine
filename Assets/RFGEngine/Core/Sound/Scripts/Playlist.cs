using System.Collections;
using UnityEngine;

namespace RFG.Core
{
  [AddComponentMenu("RFG/Core/Sound/Playlist")]
  public class Playlist : MonoBehaviour
  {
    [field: SerializeField] public PlaylistData PlaylistData { get; set; }

    private AudioSource _audioSource;
    private bool _isPlaying;
    private bool _isPaused;
    private IEnumerator _playingCoroutine;

    private void Awake()
    {
      _audioSource = GetComponent<AudioSource>();
      PlaylistData.Initialize();
    }

    private void Start()
    {
      if (PlaylistData.PlayOnStart)
      {
        Play();
      }
    }

    public void Play()
    {
      if (PlaylistData.Sounds.Length <= 0)
      {
        return;
      }
      _playingCoroutine = PlayCo();
      StartCoroutine(_playingCoroutine);
    }

    public IEnumerator PlayCo()
    {
      _isPlaying = true;
      _isPaused = false;
      yield return PlayCurrentSound();

      while (_isPlaying)
      {
        if (Application.isFocused && !_audioSource.isPlaying && !_isPaused)
        {
          if (PlaylistData.IsLast() && !PlaylistData.Loop)
          {
            _isPlaying = false;

            StopCoroutine(_playingCoroutine);
            continue;
          }

          if (_isPlaying)
          {
            PlaylistData.IncrementIndex();
            yield return PlayCurrentSound();
          }
        }
        yield return null;
      }
    }

    public void TogglePause()
    {
      if (_isPaused)
      {
        _isPaused = false;
        _audioSource.UnPause();
      }
      else
      {
        _isPaused = true;
        _audioSource.Pause();
      }
    }

    public void Stop()
    {
      StartCoroutine(StopCo());
    }

    public IEnumerator StopCo()
    {
      StopCoroutine(_playingCoroutine);
      _isPlaying = false;
      yield return _audioSource.FadeOut(PlaylistData.FadeTime);
    }

    public void Next()
    {
      StartCoroutine(NextCo());
    }

    public IEnumerator NextCo()
    {
      yield return StopCo();
      PlaylistData.IncrementIndex();
      Play();
    }

    public void Previous()
    {
      StartCoroutine(PreviousCo());
    }

    public IEnumerator PreviousCo()
    {
      yield return StopCo();
      PlaylistData.DecrementIndex();
      Play();
    }

    private IEnumerator PlayCurrentSound()
    {
      SoundData soundData = PlaylistData.GetCurrentSound();
      soundData.GenerateAudioSource(gameObject);
      yield return new WaitForSecondsRealtime(PlaylistData.WaitForSeconds);
      yield return _audioSource.FadeIn(PlaylistData.FadeTime);
    }

    public void Persist(bool persist)
    {
      if (persist)
      {
        DontDestroyOnLoad(gameObject);
      }
      else
      {
        UnityEngine.SceneManagement.SceneManager.MoveGameObjectToScene(gameObject, UnityEngine.SceneManagement.SceneManager.GetActiveScene());
      }
    }
  }
}