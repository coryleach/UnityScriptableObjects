using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameframe.ScriptableObjects.Variables
{

  [CustomPropertyDrawer(typeof(FloatReference))]
  [CustomPropertyDrawer(typeof(IntReference))]
  [CustomPropertyDrawer(typeof(StringReference))]
  [CustomPropertyDrawer(typeof(ColorReference))]
  [CustomPropertyDrawer(typeof(Vector3Reference))]
  [CustomPropertyDrawer(typeof(Vector2Reference))]
  public class VariableReferenceDrawer : PropertyDrawer
  {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      EditorGUI.BeginProperty(position, label, property);

      // Draw label
      position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

      var useLocalValue = property.FindPropertyRelative("useLocalValue");

      // Calculate rects
      Rect dropdownRect = new Rect(position.x, position.y, 85, position.height);
      Rect variableRect = new Rect(position.x + (dropdownRect.width), position.y, position.width - (dropdownRect.width), position.height);

      string[] options = { "Use Local", "Use Variable" };
      if (EditorGUI.Popup(dropdownRect, useLocalValue.boolValue ? 0 : 1, options) == 0)
      {
        useLocalValue.boolValue = true;
      }
      else
      {
        useLocalValue.boolValue = false;
      }

      if (useLocalValue.boolValue)
      {
        //Draw Local variable editor
        EditorGUI.PropertyField(variableRect, property.FindPropertyRelative("localValue"), GUIContent.none);
      }
      else
      {
        //Draw reference editor
        EditorGUI.PropertyField(variableRect, property.FindPropertyRelative("variable"), GUIContent.none);
      }

      EditorGUI.EndProperty();
    }
  }

}