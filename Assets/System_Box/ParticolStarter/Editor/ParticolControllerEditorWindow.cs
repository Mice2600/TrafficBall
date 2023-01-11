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


namespace SystemBox.ObjectCretor.Editor
{

    public class ParticolControllerEditorWindow : OdinMenuEditorWindow
    {
        [MenuItem("Tools/CreatObject")]
        public static void OpenWindow()
        {
            GetWindow<ParticolControllerEditorWindow>().Show();
        }
        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree();
            tree.Add("Creat New", new SoundProduct_CreatNew(), EditorIcons.Plus);
            for (int i = 0; i < Item.Count; i++)
                tree.Add(Item[i].Name, Item[i], EditorIcons.Image);

            return tree;
        }

        protected override void DrawMenu()
        {
            MenuTree.DrawSearchToolbar();
            base.DrawMenu();
        }
        public static List<ParticolProduct_Items> Item
        {
            get
            {
                List<ParticolProduct_Items> dsa = new List<ParticolProduct_Items>();
                List<ParticolProduct> Item_ss = Particolresurses.Item;
                Item_ss.ForEach(l =>
                { dsa.Add(new ParticolProduct_Items(l)); });
                return dsa;
            }
        }
        public class SoundProduct_CreatNew
        {
            [InfoBox("SomeThing wrong with Name", InfoMessageType = InfoMessageType.Error, VisibleIf = "NewProductName_Test")]
            [Delayed]
            public string NewNameProduct;
            // true if have eror
            private bool NewProductName_Test()
            {
                bool Ishavename = false;
                Ishavename = (NewNameProduct.IsNullOrWhitespace() || NewNameProduct == "");
                SoundResurses.Item.ForEach(i => { if (!Ishavename && (i.Name == NewNameProduct)) Ishavename = true; });
                return Ishavename;
            }


            [ValueDropdown("CountType_ValueDropdown")]
            [LabelText("CountType ")]
            public string CountType = "Single";
            private List<string> CountType_ValueDropdown() => new List<string>() { "Single", "Grope" };



            [HideIf("Audio_Test_Show_Grope")]
            public GameObject Prefab;
            [ListDrawerSettings(ShowItemCount = true, Expanded = true)]
            [InfoBox("Prefab is requared ", InfoMessageType = InfoMessageType.Error, VisibleIf = "Audio_Grope_Test")]
            [ShowIf("Audio_Test_Show_Grope")]
            public List<GameObject> Prefab_Grope;
            private bool Audio_Grope_Test()
            {
                if (CountType == "Grope")
                {
                    if (Prefab_Grope == null) return true;
                    if (Prefab_Grope.Count == 0) return true;
                }
                return false;
            }
            private bool Audio_Test()
            {
                if (CountType == "Single")
                    if (Prefab == null) return true;
                    else if (CountType == "Grope")
                    {
                        if (Prefab_Grope == null) return true;
                        if (Prefab_Grope.Count == 0) return true;
                        for (int i = 0; i < Prefab_Grope.Count; i++)
                            if (Prefab_Grope[i] == null) return true;
                    }
                return false;
            }
            private bool Audio_Test_Show_Grope() => CountType == "Grope";

            [Button(40)]
            [GUIColor("ToCreat_GUIColorButton")]
            public void ToCreat_Creat()
            {
                if ((!Audio_Test() && !NewProductName_Test()))
                {
                    CreatNewSoundProduct(
                        new Tuple<string, bool, GameObject, List<GameObject>>
                        (NewNameProduct, CountType == "Grope", Prefab, Prefab_Grope));
                    GetWindow<ParticolControllerEditorWindow>().ForceMenuTreeRebuild();
                    GetWindow<ParticolControllerEditorWindow>().MenuTree.Selection.Clear();
                    int nIndex = 0;
                    GetWindow<ParticolControllerEditorWindow>().MenuTree.MenuItems.ForEach(
                        (I, w) =>
                        {
                            if ((I.Value as ParticolProduct_Items) != null && (I.Value as ParticolProduct_Items).Name == NewNameProduct) nIndex = w;
                        });
                    GetWindow<ParticolControllerEditorWindow>().MenuTree.Selection.Add(GetWindow<ParticolControllerEditorWindow>().MenuTree.MenuItems[nIndex]);
                }
            }
            public Color ToCreat_GUIColorButton() => (!Audio_Test() && !NewProductName_Test()) ? TColor.Light_green : TColor.Red;
        }
        public class ParticolProduct_Items
        {
            public ParticolProduct_Items(ParticolProduct _soundProduct)
            {
                soundProduct = _soundProduct;
                Name = soundProduct.Name;
                AudioCountType = soundProduct.IsGrope ? "Grope" : "Single";
                for (int i = 0; i < (soundProduct.Prefab_Grope ??= new List<GameObject>()).Count; i++)
                    (Prefab_Grope ??= new List<GameObject>()).Add(soundProduct.Prefab_Grope[i]);
                Prefab = soundProduct.Prefab;
            }
            [HideLabel]
            [ReadOnly]
            [HorizontalGroup("ItemInfo")]
            [ShowInInspector]
            public string Description { get { if (soundProduct) return soundProduct.Description; return ""; } }

            [HideLabel]
            [ReadOnly]
            [HorizontalGroup("ItemInfo")]
            public ParticolProduct soundProduct;

            [Delayed]
            [OnValueChanged("NameChanged")]
            public string Name;
            private void NameChanged()
            {
                if (soundProduct)
                {
                    Item_SeaveAllValume();
                    string newPath = AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(soundProduct), Name);
                    AssetDatabase.SaveAssets();
                }

                GetWindow<ParticolControllerEditorWindow>().ForceMenuTreeRebuild();
                GetWindow<ParticolControllerEditorWindow>().MenuTree.Selection.Clear();
                int nIndex = 0;
                GetWindow<ParticolControllerEditorWindow>().MenuTree.MenuItems.ForEach(
                    (I, w) =>
                    {
                        if ((I.Value as ParticolProduct_Items) != null && (I.Value as ParticolProduct_Items).Name == Name) nIndex = w;
                    });
                GetWindow<ParticolControllerEditorWindow>().MenuTree.Selection.Add(GetWindow<ParticolControllerEditorWindow>().MenuTree.MenuItems[nIndex]);

            }


            [LabelText("Prefab Count Type")]
            [OnValueChanged("Item_SeaveAllValume", true)]
            [BoxGroup("PrefabSetings")]
            [ValueDropdown("CountType_ValueDropdown")]
            public string AudioCountType = "Single";
            private List<string> CountType_ValueDropdown() => new List<string>() { "Single", "Grope" };

            [ShowIf("ShowIf_Item_Audio")]
            [OnValueChanged("Item_SeaveAllValume", true)]

            [BoxGroup("PrefabSetings")]
            public GameObject Prefab;
            public bool ShowIf_Item_Audio() => AudioCountType == "Single";


            [HideIf("ShowIf_Item_Audio")]
            [LabelText("Prefab_Grope")]
            [OnValueChanged("Item_SeaveAllValume")]
            [BoxGroup("PrefabSetings")]
            public TList<GameObject> Prefab_Grope;
            [OnInspectorGUI]
            private void ChaechListValumes()
            {
                bool Changed = false;
                if ((Prefab_Grope ??= new TList<GameObject>()).Count != (soundProduct.Prefab_Grope ??= new TList<GameObject>()).Count) Changed = true;
                if (!Changed)
                    for (int i = 0; i < Prefab_Grope.Count; i++)
                        if (Prefab_Grope[i] != soundProduct.Prefab_Grope[i]) { Changed = true; break; }
                if (Changed) Item_SeaveAllValume();
            }





            public void Item_SeaveAllValume()
            {
                if (soundProduct)
                {
                    soundProduct.Prefab = Prefab;
                    soundProduct.Prefab_Grope = new List<GameObject>();
                    for (int i = 0; i < (Prefab_Grope ??= new List<GameObject>()).Count; i++)
                        soundProduct.Prefab_Grope.Add(Prefab_Grope[i]);
                    soundProduct.IsGrope = AudioCountType == "Grope";

                    EditorUtility.SetDirty(soundProduct);
                    AssetDatabase.SaveAssetIfDirty(soundProduct);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Resurse"> Name, isGrope, SoundProduct_Clip, SoundProduct_Clip_Grope_if </param>
        public static void CreatNewSoundProduct(Tuple<string, bool, GameObject, List<GameObject>> Resurse)
        {
            if (!File.Exists("Assets/Resources/ParticolItems")) Directory.CreateDirectory("Assets/Resources/ParticolItems");
            ParticolProduct asset = ScriptableObject.CreateInstance<ParticolProduct>();
            asset.Prefab = Resurse.Item3;
            if (Resurse.Item4 != null)
                for (int i = 0; i < Resurse.Item4.Count; i++)
                    (asset.Prefab_Grope ??= new List<GameObject>()).Add(Resurse.Item4[i]);
            asset.IsGrope = Resurse.Item2;
            AssetDatabase.CreateAsset(asset, $"Assets/Resources/ParticolItems/{Resurse.Item1}.asset");
            AssetDatabase.SaveAssets();
        }



    }
}
