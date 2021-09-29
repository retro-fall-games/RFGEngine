using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace RFG.Core
{
  using Utils;

  public class GameEditorWindow : EditorWindow
  {
    [MenuItem("RFG/Game Editor Window")]
    public static void ShowWindow()
    {
      GetWindow<GameEditorWindow>("GameEditorWindow");
    }

    public void CreateGUI()
    {
      VisualElement root = rootVisualElement;

      VisualTreeAsset visualTree = EditorUtils.LoadAssetAtDir<VisualTreeAsset>("GameEditorWindow", "GameEditorWindow.uxml");
      visualTree.CloneTree(root);

      StyleSheet styleSheet = EditorUtils.LoadAssetAtDir<StyleSheet>("GameEditorWindow", "GameEditorWindow.uss");
      root.styleSheets.Add(styleSheet);

      SetupEvents();
    }

    #region Events
    private void SetupEvents()
    {
      Button soundSetupButton = rootVisualElement.Q<Button>("sound-setup-button");
      soundSetupButton.clicked += () =>
      {
        EditorUtils.CheckTags(new string[] { "SoundTrack", "SoundAmbience", "SoundFx" });
        Debug.Log("Setup Sound Tags");
      };

      Button platformerSetupButton = rootVisualElement.Q<Button>("platformer-setup-button");
      platformerSetupButton.clicked += () =>
      {
        EditorUtils.CheckTags(new string[] { "Player", "Checkpoint", "Warp", "Level Portal", "Trigger", "AI Character", "PickUp", "Effect" });
        EditorUtils.CheckLayers(new string[] { "Player", "Platforms", "OneWayPlatforms", "MovingPlatforms", "OneWayMovingPlatforms", "Stairs", "AI Character" });
        EditorUtils.CheckSortLayers(new string[] { "Background", "Foreground", "UI" });
        Debug.Log("Setup Platformer Tags, Layers, and Sorting Layers");
      };

      Button addGameManagerButton = rootVisualElement.Q<Button>("game-manager-button");
      addGameManagerButton.clicked += () =>
      {
        EditorUtils.CreatePrefab("Assets/RFGEngine/Runtime/Core/Game/Prefabs", "GameManager");
        Debug.Log("Added the game manager to the scene");
      };
    }
    #endregion
  }
}