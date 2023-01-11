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
using UnityEngine.Audio;
namespace SystemBox
{
    public class CustomClock : OdinAttributeDrawer<ClockAttribute>
    {
        /*
        private ValueResolver<bool> das;
        protected override void Initialize()
        {
            bool dasd = ValueResolver.Get<bool>(this.Property, this.Attribut)
            base.Initialize();
        } 
         */


        protected override void DrawPropertyLayout(GUIContent label)
        {
            float clock = 0;
            if (this.Property.ValueEntry.WeakSmartValue.GetType() == typeof(float)) { clock = (float)this.Property.ValueEntry.WeakSmartValue; }
            else if (this.Property.ValueEntry.WeakSmartValue.GetType() == typeof(int)) clock = (int)this.Property.ValueEntry.WeakSmartValue;
            var ss = EditorGUILayout.GetControlRect();
            float dd = EditorGUI.FloatField(ss, "  ", clock);

            GUI.Label(ss, label.text + "     " + TMath.ShowOnClock(
                clock.ToInt(),
                  clock > TMath.ReadTime("59:59") | clock < TMath.ReadTime("-59:59"), 
                  clock > TMath.ReadTime("23:59:59") | clock < TMath.ReadTime("-23:59:59")));
            if (this.Property.ValueEntry.WeakSmartValue.GetType() == typeof(float)) this.Property.ValueEntry.WeakSmartValue = dd;
            else if (this.Property.ValueEntry.WeakSmartValue.GetType() == typeof(int)) this.Property.ValueEntry.WeakSmartValue = (int)dd;
        }
    }



}