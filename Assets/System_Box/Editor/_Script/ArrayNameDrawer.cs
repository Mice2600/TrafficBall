





using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ArrayNameAttribute))]
public class ArrayNameDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {



        try
        {
            //int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);


            //EditorGUI.ObjectField(rect, property,new GUIContent(((ArrayNameAttribute)attribute).names[pos]));
            EditorGUI.BeginProperty(rect, new GUIContent("das"), property);
            EditorGUI.ObjectField(rect, property);
            EditorGUI.EndProperty();
        }
        catch
        {
            EditorGUI.ObjectField(rect, property, label);
        }

    }
}




