using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gameframe.ScriptableObjects.Variables
{

  [CustomPropertyDrawer(typeof(AssetReference))]
  public class AssetReferenceDrawer : PropertyDrawer
  {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      EditorGUI.BeginProperty(position, label, property);

      // Draw label
      position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

      var referenceType = property.FindPropertyRelative("referenceType");
      var assetName = property.FindPropertyRelative("assetName");
      var assetPath = property.FindPropertyRelative("assetPath");
      var localValue = property.FindPropertyRelative("localValue");

      // Calculate rects
      Rect dropdownRect = new Rect(position.x, position.y, 85, position.height);
      Rect variableRect = new Rect(position.x + (dropdownRect.width), position.y, position.width - (dropdownRect.width), position.height);

      string[] options = { "Direct", "Fetch", "Variable" };

      referenceType.enumValueIndex = EditorGUI.Popup(dropdownRect, referenceType.enumValueIndex, options);

      switch(referenceType.enumValueIndex)
      {
        case 0:
          //Direct
          EditorGUI.PropertyField(variableRect, localValue, GUIContent.none);
          break;
        case 1:
          //Fetch
          var asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath.stringValue);
          asset = EditorGUI.ObjectField(variableRect, asset, typeof(GameObject), false);
          if (asset != null)
          {
            assetName.stringValue = asset.name;
            assetPath.stringValue = AssetDatabase.GetAssetPath(asset);
          }
          else
          {
            assetPath.stringValue = string.Empty;
          }
          localValue.objectReferenceValue = null;
          break;
        default:
          EditorGUI.PropertyField(variableRect, property.FindPropertyRelative("variable"), GUIContent.none);
          break;
      }

      EditorGUI.EndProperty();
    }
  }

}