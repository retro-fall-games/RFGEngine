using UnityEngine.UIElements;
using UnityEditor;

namespace RFG
{
  namespace BehaviourTree
  {
    public class InspectorView : VisualElement
    {
      public new class UxmlFactory : UxmlFactory<InspectorView, VisualElement.UxmlTraits> { }
      private Editor editor;

      public InspectorView()
      {
      }

      internal void UpdateSelection(NodeView nodeView)
      {
        Clear();
        UnityEngine.Object.DestroyImmediate(editor);
        editor = Editor.CreateEditor(nodeView.node);
        IMGUIContainer container = new IMGUIContainer(() =>
        {
          if (editor && editor.target)
          {
            editor.OnInspectorGUI();
          }
        });
        Add(container);
      }
    }
  }
}