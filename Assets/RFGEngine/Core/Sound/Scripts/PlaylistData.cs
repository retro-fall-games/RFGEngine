using UnityEngine;

namespace RFG.Core
{
  [CreateAssetMenu(fileName = "New Playlist Data", menuName = "RFG/Core/Sound/Playlist Data")]
  public class PlaylistData : ScriptableObject
  {
    public SoundData[] Sounds;
    public bool Loop = true;
    public float WaitForSeconds = 1f;
    public float FadeTime = 1f;
    public int CurrentIndex = 0;
    public bool PlayOnStart = false;

    public void Initialize()
    {
      CurrentIndex = 0;
    }

    public SoundData GetCurrentSound()
    {
      return Sounds[CurrentIndex];
    }

    public bool IsFirst()
    {
      return CurrentIndex == 0;
    }

    public bool IsLast()
    {
      return CurrentIndex == Sounds.Length - 1;
    }

    public void IncrementIndex()
    {
      int nextIndex = CurrentIndex + 1;
      if (nextIndex > Sounds.Length - 1)
      {
        nextIndex = 0;
      }
      CurrentIndex = nextIndex;
    }

    public void DecrementIndex()
    {
      int nextIndex = CurrentIndex - 1;
      if (nextIndex < 0)
      {
        nextIndex = Sounds.Length - 1;
      }
      CurrentIndex = nextIndex;
    }

  }
}