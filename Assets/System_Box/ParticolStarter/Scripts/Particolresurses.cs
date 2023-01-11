using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SystemBox.ObjectCretor
{
    public class Particolresurses : ScriptableObject
    {
        public static Dictionary<string, ParticolProduct> ItemsDictionary
        {
            get
            {
                if (_ItemsDictionary == null)
                {
                    _ItemsDictionary = new Dictionary<string, ParticolProduct>();
                    for (int i = 0; i < Item.Count; i++)
                        _ItemsDictionary.Add(Item[i].Name, Item[i]);
                }
                return _ItemsDictionary;
            }
        }
        private static Dictionary<string, ParticolProduct> _ItemsDictionary;

        public static List<ParticolProduct> Item
        {//--
            get
            {
#if UNITY_EDITOR
                bool changed = false;
                for (int i = 0; i < soundResurses.Get_SavedItems.Count; i++)
                {
                    if (i >= soundResurses.Get_SavedItems_Paths.Count)
                    {
                        changed = true;
                        break;
                    }
                    soundResurses.Get_SavedItems[i].Description = soundResurses.Get_SavedItems_Paths[i];
                    if (soundResurses.Get_SavedItems_Paths[i] != UnityEditor.AssetDatabase.GetAssetPath(soundResurses.Get_SavedItems[i]))
                    {
                        changed = true;
                        break;
                    }
                }
                if (!changed && UnityEditor.AssetDatabase.FindAssets("t:" + typeof(SoundProduct).Name).Length != soundResurses.Get_SavedItems.Count)
                { changed = true; }
                if (changed)
                {
                    soundResurses.Get_SavedItems = GetAllInstances<ParticolProduct>().ToList();
                    soundResurses.Get_SavedItems_Paths = new List<string>();
                    for (int i = 0; i < soundResurses.Get_SavedItems.Count; i++)
                    {
                        soundResurses.Get_SavedItems_Paths.Add(UnityEditor.AssetDatabase.GetAssetPath(soundResurses.Get_SavedItems[i]));
                        soundResurses.Get_SavedItems[i].Description = soundResurses.Get_SavedItems_Paths[i];
                    }
                    UnityEditor.EditorUtility.SetDirty(soundResurses);
                    UnityEditor.AssetDatabase.SaveAssetIfDirty(soundResurses);
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
                return soundResurses.SavedItems;
            }
        }

        public static Particolresurses soundResurses
        {
            get
            {
                if (_soundResurses == null)
                {
                    Resources.LoadAll("ParticolSettings/", typeof(Particolresurses)).ToList().ForEach(le => { _soundResurses ??= le as Particolresurses; });
#if UNITY_EDITOR
                    if (_soundResurses == null)
                    {
                        if (!File.Exists("Assets/ParticolStarter/Resources/ParticolSettings/ParticolSettings.asset"))
                        {
                            if (!File.Exists("Assets/ParticolStarter/Resources/ParticolSettings"))
                                Directory.CreateDirectory("Assets/ParticolStarter/Resources/ParticolSettings");

                            Particolresurses asset = ScriptableObject.CreateInstance<Particolresurses>();
                            UnityEditor.AssetDatabase.CreateAsset(asset, "Assets/ParticolStarter/Resources/ParticolSettings/ParticolSettings.asset");
                            UnityEditor.AssetDatabase.SaveAssets();
                            _soundResurses = asset;
                        }
                    }
#endif
                }
                return _soundResurses;
            }
        }
        private static Particolresurses _soundResurses;

        [HorizontalGroup("Resurse")]
        [SerializeField]
        [ListDrawerSettings(AddCopiesLastElement = false, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        [ReadOnly]
        private List<ParticolProduct> SavedItems;
        public List<ParticolProduct> Get_SavedItems { get => (SavedItems ??= new List<ParticolProduct>()); set => SavedItems = value; }
        [ListDrawerSettings(AddCopiesLastElement = false, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        [HorizontalGroup("Resurse")]
        [SerializeField]
        [ReadOnly]
        private List<string> SavedItems_Paths;
        public List<string> Get_SavedItems_Paths { get => (SavedItems_Paths ??= new List<string>()); set => SavedItems_Paths = value; }


    }
}




