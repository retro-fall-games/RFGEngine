using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace RFG.Core
{
  using Utils;

  [CustomEditor(typeof(Playlist))]
  public class PlaylistInspector : Editor
  {
    private VisualElement rootElement;
    private Editor editor;

    public void OnEnable()
    {
      rootElement = new VisualElement();

      var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/RFGEngine/Core/Sound/Editor/PlaylistInspector/PlaylistInspector.uss");
      rootElement.styleSheets.Add(styleSheet);
    }

    public override VisualElement CreateInspectorGUI()
    {
      UnityEngine.Object.DestroyImmediate(editor);
      editor = Editor.CreateEditor(this);
      IMGUIContainer container = new IMGUIContainer(() =>
      {
        if (target)
        {
          OnInspectorGUI();
        }
      });
      rootElement.Add(container);

      var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/RFGEngine/Core/Sound/Editor/PlaylistInspector/PlaylistInspector.uxml");
      visualTree.CloneTree(rootElement);

      Playlist playlist = (Playlist)target;

      Button generateAudioSourceButton = rootElement.Q<Button>("generate");
      generateAudioSourceButton.clicked += () =>
      {
        if (playlist.PlaylistData.Sounds.Length > 0)
        {
          playlist.PlaylistData.Sounds[0].GenerateAudioSource(playlist.gameObject);
        }
        else
        {
          LogExt.Warn<PlaylistInspector>($"Playlist has no sounds");
        }
      };

      Button prevButton = rootElement.Q<Button>("prev");
      prevButton.clicked += () =>
      {
        playlist.Previous();
      };

      Button stopButton = rootElement.Q<Button>("stop");
      stopButton.clicked += () =>
      {
        playlist.Stop();
      };


      Button playButton = rootElement.Q<Button>("play");
      playButton.clicked += () =>
      {
        playlist.Play();
      };

      Button pauseButton = rootElement.Q<Button>("pause");
      pauseButton.clicked += () =>
      {
        playlist.TogglePause();
      };

      Button nextButton = rootElement.Q<Button>("next");
      nextButton.clicked += () =>
      {
        playlist.Next();
      };

      return rootElement;
    }
  }
}