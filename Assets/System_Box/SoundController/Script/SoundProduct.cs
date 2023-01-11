using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemBox;
using Sirenix.OdinInspector;
using UnityEngine.Audio;

public class SoundProduct : ScriptableObject
{
    [ReadOnly]
    [ShowInInspector]
    public string Name => this.name;
    [ReadOnly]
    public string Description;

    [ReadOnly]
    [BoxGroup]
    public SoundProduct_Clip Audio;
    [ReadOnly]
    public List<SoundProduct_Clip> Audio_Grope;
    [ReadOnly]
    public bool IsGrope;
    [ReadOnly]
    public string CreatTuyp = "Infinity";
    [ReadOnly]
    public int MaxPlayAudio = 6;
    [ReadOnly]
    public string when_full = "Dont_Call";
    
    public AudioMixerGroup output;
    public bool Loop = false;
    public bool Ues_List_Valume;
    public AnimationCurve List_Valume_Curve;
    public int Infinity_Protsents;
}


[HideLabel]
[System.Serializable]
public class SoundProduct_Clip
{
    public SoundProduct_Clip() { }
    public SoundProduct_Clip(SoundProduct_Clip s) 
    {
        Audio = s.Audio;
        Volume = s.Volume;
        Pitch = s.Pitch;
    }
    [Required]
    [ClipPlayer]
    public AudioClip Audio;
    [Range(0, 1)]
    public float Volume = 1;
    [Range(-3, 2)]
    public float Pitch = 1;
}
