using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using SystemBox.Simpls;
using SystemBox;


//
namespace SystemBox
{
    
    public static class AudioPlayer 
    {

        public static void PlayAudio(string ID)
        {
            if (!Application.isPlaying) return;
            try
            {
                Engine.Engine.Update_Engins("EngineAudioSettings", Update);
                if (SoundResurses.ItemsDictionary.ContainsKey(ID))
                {
                    CallMee_System(SoundResurses.ItemsDictionary[ID]);
                }
                else
                {
                    Debug.Log("ID => " + ID + " not found from Audio boxes ");
                }
            }
            catch (Exception)
            {

            }
            
        }
        public static void StopAudio(string ID)
        {
            if (!Application.isPlaying) return;
            try
            {
                if (ObjectsComponent.ContainsKey(ID))
                {
                    if (ObjectsComponent[ID] != null) 
                    {
                        for (int g = 0; g < ObjectsComponent[ID].Count; g++)
                        {
                            if (ObjectsComponent[ID][g] != null) 
                            {
                                ObjectsComponent[ID][g].Stop();
                                ObjectsComponent[ID][g].gameObject.ToDestroy();
                            }
                        }
                    }
                    ObjectsComponent[ID] = new TList<AudioSource>();
                }
                else return; //eror not faund}
            }
            catch (Exception){ }
            
        }
        public static void StopAllAudio()
        {
            if (!Application.isPlaying) return;
            try
            {
                
                List<string> keyList = new List<string>(ObjectsComponent.Keys);

                for (int i = 0; i < keyList.Count; i++)
                {
                    for (int g = 0; g < ObjectsComponent[keyList[i]].Count; g++)
                    {
                        if (ObjectsComponent[keyList[i]] != null)
                        {
                            if (ObjectsComponent[keyList[i]][g] != null)
                            {
                                ObjectsComponent[keyList[i]][g].Stop();
                                ObjectsComponent[keyList[i]][g].gameObject.ToDestroy();
                            }
                        }
                    }
                    ObjectsComponent[keyList[i]] = new TList<AudioSource>();
                }
            }
            catch {}
            
        }

        
        private static TList<AudioSource> ToDestroy_Audios { get => (_ToDestroy_Audios ??= new TList<AudioSource>()); set => _ToDestroy_Audios = value; }
        private static TList<AudioSource> _ToDestroy_Audios;




        private static Dictionary<string, TList<AudioSource>> ToDestroy_Audios_As_Passiver
        { get { if (_ToDestroy_Audios_As_Passiver == null) _ToDestroy_Audios_As_Passiver  = new Dictionary<string, TList<AudioSource>>(); return _ToDestroy_Audios_As_Passiver; } set => _ToDestroy_Audios_As_Passiver = value; }
        private static Dictionary<string, TList<AudioSource>> _ToDestroy_Audios_As_Passiver;



        private static void Update()
        {
            for (int i = 0; i < ToDestroy_Audios.Count; i++)
            {
                if (ToDestroy_Audios[i] == null) { ToDestroy_Audios.RemoveAt(i); break; }
                if (!ToDestroy_Audios[i].isPlaying)
                {
                    ToDestroy_Audios[i].gameObject.ToDestroy();
                    ToDestroy_Audios.RemoveAt(i);
                    break;
                }
            }
            List<string> Passiver_keyList = new List<string>(ToDestroy_Audios_As_Passiver.Keys);
            for (int i = 0; i < Passiver_keyList.Count; i++)
            {
                for (int IN_I = 0; IN_I < ToDestroy_Audios_As_Passiver[Passiver_keyList[i]].Count; IN_I++)
                {
                    if (ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I] == null) 
                    {ToDestroy_Audios_As_Passiver[Passiver_keyList[i]].RemoveAt(IN_I);break; }
                    ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I].volume = 
                        Mathf.MoveTowards(ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I].volume, 0, 1f * IN_I * Time.deltaTime);
                    if(ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I].volume == 0f) ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I].Stop();
                    
                    if (!ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I].isPlaying)
                    {
                        ToDestroy_Audios_As_Passiver[Passiver_keyList[i]][IN_I].gameObject.ToDestroy();
                        ToDestroy_Audios_As_Passiver[Passiver_keyList[i]].RemoveAt(IN_I);
                        break;
                    }
                }
            }
            
            
            List<string> keyList = new List<string>(ObjectsComponent.Keys);

            for (int i = 0; i < keyList.Count; i++)
                for (int a = 0; a < ObjectsComponent[keyList[i]].Count; a++) 
                { if (ObjectsComponent[keyList[i]][a] == null) { ObjectsComponent[keyList[i]].RemoveAt(a); break; } }
            for (int i = 0; i < keyList.Count; i++)
            {
                SoundProduct NItem = SoundResurses.ItemsDictionary[keyList[i]];
                if (NItem.Ues_List_Valume) 
                {
                    for (int f = 0; f < ObjectsComponent[keyList[i]].Count; f++)
                    {
                        int MMCount = (NItem.CreatTuyp == "Infinity") ? NItem.Infinity_Protsents : (NItem.CreatTuyp == "Limit") ? NItem.MaxPlayAudio : 0;
                        TList<AudioSource> audioSources = ObjectsComponent[keyList[i]].SetCount(MMCount,true).Rotate(true);
                        List<float> Tmess = TMath.GetBitwinTimes(MMCount, NItem.List_Valume_Curve);
                        for (int g = 0; g < MMCount; g++)
                        {
                            if (audioSources[g] != null) 
                            {
                                float Volume = 1;
                                if (NItem.IsGrope)
                                {
                                    for (int a = 0; a < NItem.Audio_Grope.Count; a++)
                                    {
                                        if (NItem.Audio_Grope[a].Audio == audioSources[g]) { Volume = NItem.Audio_Grope[a].Volume;  break; }
                                    }    
                                }else 
                                {
                                    Volume = NItem.Audio.Volume;
                                }
                                audioSources[g].volume = Volume * Tmess[g]; 
                            }
                        }
                    }
                }
            }
            
        }

        private static Dictionary<string, TList<AudioSource>> ObjectsComponent 
        {get { if (_ObjectsComponent == null) _ObjectsComponent = new Dictionary<string, TList<AudioSource>>(); return _ObjectsComponent; } set => _ObjectsComponent = value; }
        private static Dictionary<string, TList<AudioSource>> _ObjectsComponent;

        private static void CallMee_System(SoundProduct product)
        {
            SoundProduct_Clip AudioToPley = null;
            if (product.IsGrope)
            {
                TList<SoundProduct_Clip> Lists = new TList<SoundProduct_Clip>();
                for (int i = 0; i < product.Audio_Grope.Count; i++)
                {
                    if (product.Audio_Grope[i] != null && product.Audio_Grope[i].Audio != null)
                        Lists += product.Audio_Grope[i];
                }
                if (Lists.IsEnpty()) { Debug.Log(product.Name + "'s grope AudioClips NotFound"); return; }//eror Audio not found}
                AudioToPley = Lists.RandomItem;
            }
            else 
            {
                if (product.Audio == null || product.Audio.Audio == null) { Debug.Log(product.Name + "'s AudioClip NotFound"); return; }//eror Audio not found
                AudioToPley = product.Audio;
            }
            if ( AudioToPley == null) { Debug.Log(product.Name + "'s AudioClip NotFound"); return; }//eror Audio not found

            if (!ObjectsComponent.ContainsKey(product.Name)) ObjectsComponent.Add(product.Name,new TList<AudioSource>());

            if (product.CreatTuyp == "Limit")
            {
                for (int i = 0; i < ObjectsComponent[product.Name].Count; i++)
                {
                    if (!ObjectsComponent[product.Name][i].isPlaying)
                    {
                        AudioSource NN = ObjectsComponent[product.Name][i];
                        ObjectsComponent[product.Name].RemoveAt(i);
                        ObjectsComponent[product.Name].AddTo(0, NN);

                        ObjectsComponent[product.Name][0].gameObject.name = "AudioHaiden - " + AudioToPley.Audio.name;
                        ObjectsComponent[product.Name][0].clip = AudioToPley.Audio;
                        ObjectsComponent[product.Name][0].volume = AudioToPley.Volume;
                        ObjectsComponent[product.Name][0].pitch = AudioToPley.Pitch;
                        ObjectsComponent[product.Name][0].Play();
                        return;
                    }
                }
                if (ObjectsComponent[product.Name].Count > product.MaxPlayAudio - 1)
                {
                    if (product.when_full == "Stop_First_AndPlay")
                    {
                        AudioSource NN = ObjectsComponent[product.Name][ObjectsComponent[product.Name].LastIndex];
                        if(!ToDestroy_Audios_As_Passiver.ContainsKey(product.Name)) ToDestroy_Audios_As_Passiver.Add(product.Name, new TList<AudioSource>());
                        ToDestroy_Audios_As_Passiver[product.Name] += ObjectsComponent[product.Name][ObjectsComponent[product.Name].LastIndex];
                        ObjectsComponent[product.Name].RemoveAt(ObjectsComponent[product.Name].LastIndex);
                        Creat();
                        return;
                    }
                    else if (product.when_full == "Dont_Call")
                    {
                        return;
                    }
                }
                Creat();
            }
            else if(product.CreatTuyp == "Infinity") { Creat(); }
            void Creat()
            {
                GameObject NObject = new GameObject("AudioHaiden - " + AudioToPley.Audio.name);
               // NObject.hideFlags = HideFlags.HideInHierarchy;
                NObject.AddComponent<AudioSource>().clip = AudioToPley.Audio;
                NObject.GetComponent<AudioSource>().volume = AudioToPley.Volume;
                NObject.GetComponent<AudioSource>().pitch = AudioToPley.Pitch;
                NObject.GetComponent<AudioSource>().loop = product.Loop;
                NObject.GetComponent<AudioSource>().outputAudioMixerGroup = product.output;
                NObject.GetComponent<AudioSource>().Play();
                MonoBehaviour.DontDestroyOnLoad(NObject);
                ObjectsComponent[product.Name].AddTo(0, NObject.GetComponent<AudioSource>());
                if(product.CreatTuyp == "Infinity") ToDestroy_Audios += NObject.GetComponent<AudioSource>(); 
            }
        }
        
    }
}








