using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace RFG.Core
{
  [CustomEditor(typeof(Sound))]
  public class SoundInspector : Editor
  {
    private VisualElement rootElement;
    private Editor editor;

    public void OnEnable()
    {
      rootElement = new VisualElement();

      var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/RFGEngine/Core/Sound/Editor/SoundInspector/SoundInspector.uss");
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

      var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/RFGEngine/Core/Sound/Editor/SoundInspector/SoundInspector.uxml");
      visualTree.CloneTree(rootElement);

      Sound sound = (Sound)target;

      Button generateAudioSourceButton = rootElement.Q<Button>("generate");
      generateAudioSourceButton.clicked += () =>
      {
        sound.SoundData.GenerateAudioSource(sound.gameObject);
      };

      Button stopButton = rootElement.Q<Button>("stop");
      stopButton.clicked += () =>
      {
        sound.Stop();
      };

      Button playButton = rootElement.Q<Button>("play");
      playButton.clicked += () =>
      {
        sound.Play();
      };

      return rootElement;
    }
  }
}