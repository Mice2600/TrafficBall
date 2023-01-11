using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SystemBox;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using Sirenix;
using SystemBox.Simpls;
using System.Reflection;
using System;
using Sirenix.OdinInspector;

[CustomPropertyDrawer(typeof(CurveAttribute))]
public class CurveDrawer : OdinAttributeDrawer<CurveAttribute>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        AnimationCurve dd = this.Property.ValueEntry.WeakSmartValue as AnimationCurve;
        dd = EditorGUI.CurveField(EditorGUILayout.GetControlRect(), new GUIContent(this.Property.NiceName), dd, Color.cyan, new Rect(this.Attribute.PosX, this.Attribute.PosY, this.Attribute.RangeX, this.Attribute.RangeY));
        this.Property.ValueEntry.WeakSmartValue = dd;
    }
}
