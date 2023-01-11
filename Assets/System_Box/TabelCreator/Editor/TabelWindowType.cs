using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using System.Collections.Generic;
using System.IO;
using SystemBox;
using SystemBox.Simpls;
using SystemBox.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using Sirenix.Utilities.Editor;
using System;
using System.Reflection;

public abstract class TabelWindowType<T> : OdinMenuEditorWindow  where T : TabelScriptableObject
{
    public virtual string GetCostumeItemName(string CorrentName) 
    {
        return CorrentName;
    }

    public static void OpenWindow()
    {
        GetWindow(GattLastChild()).Show();

        Type GattLastChild()
        {

            var allTypes = Assembly.GetAssembly(typeof(TabelWindowType<T>)).GetTypes();

            foreach (var myType in allTypes)
            {
                // Check if this type is subclass of your base class
                bool isSubType = myType.IsSubclassOf(typeof(TabelWindowType<T>));
                if (!myType.IsAbstract)
                {
                    // If it is sub-type, then print its name in Debug window.
                    if (isSubType)
                    {
                        return myType;
                    }
                }
            }
            throw new Exception("Type NotFound");
        }

    }

    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = new OdinMenuTree();
        List<T> _Itemss = TabelRessursSettings<T>.Items;
        for (int i = 0; i < _Itemss.Count; i++)//
            tree.Add(GetCostumeItemName(_Itemss[i].Name), _Itemss[i], EditorIcons.Image);
        return tree;
    }
    protected override void DrawMenu()
    {
        MenuTree.DrawSearchToolbar();
        base.DrawMenu();
    }

}