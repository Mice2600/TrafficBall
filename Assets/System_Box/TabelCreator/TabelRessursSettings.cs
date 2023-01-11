using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SystemBox;
using Sirenix.OdinInspector;
using UnityEngine;
using System.Reflection;

public abstract class TabelScriptableObject : SerializedScriptableObject
{
    public abstract string Name { get; }
}
public abstract class TabelRessursSettings<T> : ScriptableObject where T : TabelScriptableObject
{
    public static Dictionary<string, T> ItemsDictionary
    {
        get
        {

            if (_ItemsDictionary != null) 
            {
                TList<string> vs = new TList<string>(_ItemsDictionary.Keys);
                for (int i = 0; i < vs.Count; i++)
                {
                    if (_ItemsDictionary[vs[i]].Name != vs[i])
                    {
                        _ItemsDictionary = null;
                        break;
                    }
                }
            }
            if (_ItemsDictionary == null)
            {
                _ItemsDictionary = new Dictionary<string, T>();
                for (int i = 0; i < Items.Count; i++)
                    _ItemsDictionary.Add(Items[i].Name, Items[i]);
            }
            return _ItemsDictionary;
        }
    }
    private static Dictionary<string, T> _ItemsDictionary;
    public static List<T> Items
    {//--
        get
        {
#if UNITY_EDITOR
            bool changed = false;
            if(ResursesSettings.Get_SavedItems == null) changed = true;
            if (changed == false) 
            {
                for (int i = 0; i < ResursesSettings.Get_SavedItems.Count; i++)
                {
                    if (ResursesSettings.Get_SavedItems[i] == null)
                    {
                        changed = true;
                        break;
                    }
                }
            }
            
            if (!changed && UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name).Length != ResursesSettings.Get_SavedItems.Count)
            { changed = true; }
            if (changed)
            {
                ResursesSettings.Get_SavedItems = GetAllInstances<T>().ToList();
                UnityEditor.EditorUtility.SetDirty(ResursesSettings);
                UnityEditor.AssetDatabase.SaveAssetIfDirty(ResursesSettings);
                UnityEditor.AssetDatabase.SaveAssets();
                UnityEditor.AssetDatabase.Refresh();
            }
            T[] GetAllInstances<T>() where T : ScriptableObject
            {
                string[] guids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
                T[] a = new T[guids.Length];
                for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
                {
                    string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guids[i]);
                    a[i] = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
                }
                return a;
            }
#endif
            return ResursesSettings.SavedItems;
        }
    }


    private static TabelRessursSettings<T> ResursesSettings
    {
        get
        {
            if (_Me == null)
            {
                Resources.LoadAll("TabelSettings/", typeof(TabelRessursSettings<T>)).ToList().ForEach(le => { _Me ??= le as TabelRessursSettings<T>; });
#if UNITY_EDITOR
                if (_Me == null)
                {

                    if (!File.Exists($"Assets/System_Box/Resources/TabelSettings/{typeof(T)}Settings.asset"))
                    {
                        Directory.CreateDirectory($"Assets/System_Box/Resources/TabelSettings");
                        ScriptableObject asset = ScriptableObject.CreateInstance(GattLastChildeName());
                        UnityEditor.AssetDatabase.CreateAsset(asset, $"Assets/System_Box/Resources/TabelSettings/{typeof(T)}Settings.asset");
                        UnityEditor.AssetDatabase.SaveAssets();
                        _Me = asset as TabelRessursSettings<T>;
                    }
                }
#endif
            }
            return _Me;

            string GattLastChildeName()
            {

                var allTypes = Assembly.GetAssembly(typeof(TabelRessursSettings<T>)).GetTypes();

                foreach (var myType in allTypes)
                {
                    // Check if this type is subclass of your base class
                    bool isSubType = myType.IsSubclassOf(typeof(TabelRessursSettings<T>));
                    if (!myType.IsAbstract)
                    {
                        // If it is sub-type, then print its name in Debug window.
                        if (isSubType)
                        {
                            return myType.Name;
                        }
                    }
                }
                throw new Exception("Type NotFound");
            }
        }
    }

    private static TabelRessursSettings<T> _Me;



    [SerializeField]
    [ListDrawerSettings(AddCopiesLastElement = false, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
    [ReadOnly]
    private List<T> SavedItems;
    public List<T> Get_SavedItems { get => (SavedItems ??= new List<T>()); set => SavedItems = value; }


    

}
