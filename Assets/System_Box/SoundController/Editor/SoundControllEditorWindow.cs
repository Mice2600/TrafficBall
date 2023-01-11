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

public class SoundControllEditorWindow : OdinMenuEditorWindow
{
    [MenuItem("Tools/SystemBox/SoundControll")]
    [MenuItem("Tools/SystemBox/Hotkeys/%h %h")]
    public static void OpenWindow()
    {
        GetWindow<SoundControllEditorWindow>().Show();
    }
    protected override OdinMenuTree BuildMenuTree()
    {
        OdinMenuTree tree = new OdinMenuTree();

        tree.Add("Creat New", new SoundProduct_CreatNew(), EditorIcons.Plus);
        
        for (int i = 0; i < Item.Count; i++)
            tree.Add(Item[i].Name, Item[i], EditorIcons.Sound);

        return tree;
    }

    private static bool _chengeSetted;
    protected override void DrawMenu()
    {
        MenuTree.DrawSearchToolbar();
        //MenuTree.DrawMenuTree();
        if (!_chengeSetted) { MenuTree.Selection.SelectionChanged += (G) => { AudioPlayerSettings.StopAllPlayers(); }; _chengeSetted = true; }
        base.DrawMenu();
    }
    public static List<SoundProduct_Items> Item
    {
        get
        {
            List<SoundProduct_Items> dsa = new List<SoundProduct_Items>();
            List<SoundProduct> Item_ss = SoundResurses.Item;
            Item_ss.ForEach(l =>
            { dsa.Add(new SoundProduct_Items(l)); });
            return dsa;
        }
    }
    public class SoundProduct_CreatNew
    {
        #region ToCreat
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
        public SoundProduct_Clip Audio;
        [ListDrawerSettings(ShowItemCount = true, Expanded = true)]
        [InfoBox("Audio is requared ", InfoMessageType = InfoMessageType.Error, VisibleIf = "Audio_Grope_Test")]
        [ShowIf("Audio_Test_Show_Grope")]
        public List<SoundProduct_Clip> Audio_Grope;
        private bool Audio_Grope_Test()
        {
            if (CountType == "Grope")
            {
                if (Audio_Grope == null) return true;
                if (Audio_Grope.Count == 0) return true;
            }
            return false;
        }
        private bool Audio_Test()
        {
            if (CountType == "Single")
            {
                if (Audio == null) return true;
                if (Audio.Audio == null) return true;
            }
            else if (CountType == "Grope")
            {
                if (Audio_Grope == null) return true;
                if (Audio_Grope.Count == 0) return true;
                for (int i = 0; i < Audio_Grope.Count; i++)
                {
                    if (Audio_Grope[i] == null) return true;
                    if (Audio_Grope[i].Audio == null) return true;
                }
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
                    new System.Tuple<string, bool, SoundProduct_Clip, List<SoundProduct_Clip>>
                    (NewNameProduct, CountType == "Grope", new SoundProduct_Clip(Audio), Audio_Grope));
                GetWindow<SoundControllEditorWindow>().ForceMenuTreeRebuild();
                GetWindow<SoundControllEditorWindow>().MenuTree.Selection.Clear();
                int nIndex = 0;
                GetWindow<SoundControllEditorWindow>().MenuTree.MenuItems.ForEach(
                    (I, w) =>
                    {
                        if ((I.Value as SoundProduct_Items) != null && (I.Value as SoundProduct_Items).Name == NewNameProduct) nIndex = w;
                    });
                GetWindow<SoundControllEditorWindow>().MenuTree.Selection.Add(GetWindow<SoundControllEditorWindow>().MenuTree.MenuItems[nIndex]);
            }
        }
        public Color ToCreat_GUIColorButton() => (!Audio_Test() && !NewProductName_Test()) ? TColor.Light_green : TColor.Red;
        #endregion
    }
    public class SoundProduct_Items
    {
        public SoundProduct_Items() { }

        #region EditorUp

        #endregion

        #region Item

        public SoundProduct_Items(SoundProduct _soundProduct)
        {

            soundProduct = _soundProduct;
            Name = soundProduct.Name;
            CreatTuyp = soundProduct.CreatTuyp;
            AudioCountType = soundProduct.IsGrope ? "Grope" : "Single";

            for (int i = 0; i < (soundProduct.Audio_Grope ??= new List<SoundProduct_Clip>()).Count; i++)
                (Audio_Grope ??= new List<SoundProduct_Clip>()).Add(new SoundProduct_Clip(soundProduct.Audio_Grope[i]));
            Audio = new SoundProduct_Clip(soundProduct.Audio);

            MaxPlayAudio = soundProduct.MaxPlayAudio;
            when_full = soundProduct.when_full;
            outputAudioMixerGroup = soundProduct.output;
            Loop = soundProduct.Loop;
            UesListValume = soundProduct.Ues_List_Valume;
            List_Valume_Curve = soundProduct.List_Valume_Curve;
            Infinity_Protsents = soundProduct.Infinity_Protsents;
        }

        [HideLabel]
        [ReadOnly]
        [HorizontalGroup("ItemInfo")]
        [ShowInInspector]
        public string Description { get { if (soundProduct) return soundProduct.Description; return ""; } }
        [HideLabel]
        [ReadOnly]
        [HorizontalGroup("ItemInfo")]

        public SoundProduct soundProduct;
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

            GetWindow<SoundControllEditorWindow>().ForceMenuTreeRebuild();
            GetWindow<SoundControllEditorWindow>().MenuTree.Selection.Clear();
            int nIndex = 0;
            GetWindow<SoundControllEditorWindow>().MenuTree.MenuItems.ForEach(
                (I, w) =>
                {
                    if ((I.Value as SoundProduct_Items) != null && (I.Value as SoundProduct_Items).Name == Name) nIndex = w;
                });
            GetWindow<SoundControllEditorWindow>().MenuTree.Selection.Add(GetWindow<SoundControllEditorWindow>().MenuTree.MenuItems[nIndex]);

        }


        #region Infinity Limit
        [ValueDropdown("Item_CreatTuyp_ValueDropdown")]
        [OnValueChanged("Item_SeaveAllValume")]
        [BoxGroup("AudioSetings")]
        public string CreatTuyp = "Infinity";
        private List<string> Item_CreatTuyp_ValueDropdown() => new List<string>() { "Infinity", "Limit" };

        [ShowIf("MaxPlayAudio_ShowIf")]
        [MinValue(1)]
        [BoxGroup("AudioSetings")]
        [LabelText("Max Players Count")]
        [OnValueChanged("Item_SeaveAllValume")]
        public int MaxPlayAudio = 6;
        private bool MaxPlayAudio_ShowIf() => CreatTuyp == "Limit";

        [ShowIf("MaxPlayAudio_ShowIf")]
        [ValueDropdown("when_ful_ValueDropdown")]
        [BoxGroup("AudioSetings")]
        [LabelText("When Players Full")]
        [OnValueChanged("Item_SeaveAllValume")]
        public string when_full = "Dont_Call";
        public List<string> when_ful_ValueDropdown() => new List<string>() { "Stop_First_AndPlay", "Dont_Call" };


        #endregion
        #region Audio
        [LabelText("Audio Count Type")]
        [OnValueChanged("Item_SeaveAllValume", true)]
        [BoxGroup("AudioSetings")]
        [ValueDropdown("CountType_ValueDropdown")]
        public string AudioCountType = "Single";
        private List<string> CountType_ValueDropdown() => new List<string>() { "Single", "Grope" };

        [ShowIf("ShowIf_Item_Audio")]
        [OnValueChanged("Item_SeaveAllValume", true)]

        [BoxGroup("AudioSetings")]
        public SoundProduct_Clip Audio;
        public bool ShowIf_Item_Audio() => AudioCountType == "Single";


        [HideIf("ShowIf_Item_Audio")]
        [LabelText("Audio_Grope")]
        [OnValueChanged("Item_SeaveAllValume")]
        [BoxGroup("AudioSetings")]
        public TList<SoundProduct_Clip> Audio_Grope;
        [OnInspectorGUI]
        private void ChaechListValumes()
        {
            bool Changed = false;
            
            if ((Audio_Grope ??= new TList<SoundProduct_Clip>()).Count != (soundProduct.Audio_Grope ??= new TList<SoundProduct_Clip>()).Count) Changed = true;
            if (!Changed)
            {
                for (int i = 0; i < Audio_Grope.Count; i++)
                {
                    if (Audio_Grope[i].Volume != soundProduct.Audio_Grope[i].Volume) { Changed = true; break; }
                    if (Audio_Grope[i].Audio != soundProduct.Audio_Grope[i].Audio) { Changed = true; break; }
                    if (Audio_Grope[i].Pitch != soundProduct.Audio_Grope[i].Pitch) { Changed = true; break; }
                }
            }

            if (Changed) Item_SeaveAllValume();
        }

        [BoxGroup("AudioSetings")]
        [LabelText("Output Mixer")]
        [OnValueChanged("Item_SeaveAllValume")]
        public AudioMixerGroup outputAudioMixerGroup;

        #endregion
        [BoxGroup("AudioSetings")]
        [OnValueChanged("Item_SeaveAllValume")]
        public bool Loop = false;


        #region Ues List Valume tools
        [ToggleGroup("UesListValume")]
        [LabelText("Ues List Valume")]
        [OnValueChanged("Item_SeaveAllValume")]
        public bool UesListValume;

        [LabelText("List Valume Curve")]
        [ToggleGroup("UesListValume")]
        [Curve(0, 0, 1, 1)]
        public AnimationCurve List_Valume_Curve;
        [ToggleGroup("UesListValume")]
        [ShowIf("Item_Infinity_Frotsents_ShowIf")]
        [MinValue(1)]
        [LabelText("MaxPlayAudio")]
        public int Infinity_Protsents;
        private bool Item_Infinity_Frotsents_ShowIf() => CreatTuyp == "Limit";

        [OnInspectorGUI]
        public void List_Valume_Fixser()
        {
            if (List_Valume_Curve == null) List_Valume_Curve = new AnimationCurve();
            if (List_Valume_Curve.keys == null) { List_Valume_Curve.keys = new Keyframe[] { }; List_Valume_Curve.AddKey(0, 0); List_Valume_Curve.AddKey(1, 1); }
            if (List_Valume_Curve.keys.Length == 1) List_Valume_Curve.AddKey(1, 1);
            if (List_Valume_Curve.keys.Length == 0) { List_Valume_Curve.AddKey(0, 0); List_Valume_Curve.AddKey(1, 1); }
        }
        #endregion



        public void Item_SeaveAllValume()
        {
            if (soundProduct)
            {
                soundProduct.Audio = new SoundProduct_Clip { Audio = Audio.Audio, Pitch = Audio.Pitch, Volume = Audio.Volume };
                soundProduct.when_full = when_full;
                soundProduct.CreatTuyp = CreatTuyp;
                soundProduct.MaxPlayAudio = MaxPlayAudio;
                soundProduct.Audio_Grope = new List<SoundProduct_Clip>();
                for (int i = 0; i < (Audio_Grope ??= new List<SoundProduct_Clip>()).Count; i++)
                    soundProduct.Audio_Grope.Add(new SoundProduct_Clip { Audio = Audio_Grope[i].Audio, Pitch = Audio_Grope[i].Pitch, Volume = Audio_Grope[i].Volume });
                soundProduct.output = outputAudioMixerGroup;
                soundProduct.Loop = Loop;
                soundProduct.Ues_List_Valume = UesListValume;
                soundProduct.List_Valume_Curve = List_Valume_Curve;
                soundProduct.Infinity_Protsents = Infinity_Protsents;
                soundProduct.IsGrope = AudioCountType == "Grope";

                EditorUtility.SetDirty(soundProduct);
                AssetDatabase.SaveAssetIfDirty(soundProduct);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();


            }
        }

        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Resurse"> Name, isGrope, SoundProduct_Clip, SoundProduct_Clip_Grope_if </param>
    public static void CreatNewSoundProduct(System.Tuple<string, bool, SoundProduct_Clip, List<SoundProduct_Clip>> Resurse)
    {

        if (!File.Exists("Assets/Resources/SoundIpems")) Directory.CreateDirectory("Assets/Resources/SoundIpems");
        SoundProduct asset = ScriptableObject.CreateInstance<SoundProduct>();
        asset.Audio = new SoundProduct_Clip(Resurse.Item3);
        if(Resurse.Item4 != null) 
        {
            for (int i = 0; i < Resurse.Item4.Count; i++)
                (asset.Audio_Grope ??= new List<SoundProduct_Clip>()).Add(new SoundProduct_Clip(Resurse.Item4[i]));
        }
        asset.IsGrope = Resurse.Item2;
        asset.CreatTuyp = "Infinity";
        asset.when_full = "Dont_Call";
        AssetDatabase.CreateAsset(asset, $"Assets/Resources/SoundIpems/{Resurse.Item1}.asset");
        AssetDatabase.SaveAssets();
    }



}

