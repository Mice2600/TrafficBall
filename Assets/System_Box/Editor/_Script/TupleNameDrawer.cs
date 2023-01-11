using UnityEngine;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using System.Collections.Generic;

public class TupleNameDrawer : OdinAttributeDrawer<TupleNameAttribute>
{
    protected override void DrawPropertyLayout(GUIContent label)
    {
        for (int i = 0; i < this.Property.Children.Count; i++)
        {
            if (this.Property.Children[i].Name == "Item" + (i + 1))
            {
                this.Property.Children[i].Label = new GUIContent(this.Attribute.names[i]);
            }
        }
        this.CallNextDrawer(label);
    }
}


