using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemBox;
using Sirenix.OdinInspector;
using UnityEngine.Audio;

namespace SystemBox.ObjectCretor
{
    public class ParticolProduct : ScriptableObject
    {
        [ReadOnly]
        [ShowInInspector]
        public string Name => this.name;
        [ReadOnly]
        public string Description;

        [ReadOnly]
        [BoxGroup]
        public GameObject Prefab;
        [ReadOnly]
        public List<GameObject> Prefab_Grope;
        [ReadOnly]
        public bool IsGrope;
    }
}