using System;
using UnityEngine.UIElements;

namespace RFG.Utils
{
  public static class ElementUtilities
  {
    public static Button CreateButton(string text, Action onClick = null)
    {
      Button button = new Button(onClick)
      {
        text = text
      };
      return button;
    }

    public static Foldout CreateFoldout(string title, bool collapsed = false)
    {
      Foldout foldout = new Foldout()
      {
        text = title,
        value = !collapsed
      };
      return foldout;
    }

    public static TextField CreateTextField(string value = null, string label = null, EventCallback<ChangeEvent<string>> onValueChanged = null)
    {
      TextField textField = new TextField()
      {
        value = value,
        label = label
      };
      if (onValueChanged != null)
      {
        textField.RegisterValueChangedCallback(onValueChanged);
      }
      return textField;
    }

    public static TextField CreateTextArea(string value = null, string label = null, EventCallback<ChangeEvent<string>> onValueChanged = null)
    {
      TextField textArea = CreateTextField(value, label, onValueChanged);
      textArea.multiline = true;
      return textArea;
    }

  }
}