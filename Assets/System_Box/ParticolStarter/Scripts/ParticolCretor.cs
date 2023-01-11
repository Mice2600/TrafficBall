using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using SystemBox.Simpls;
using SystemBox.Engine;
using SystemBox;

namespace SystemBox.ObjectCretor
{
    public class ParticolCretor 
    {
        public static GameObject PlayParticol(string ID, Vector3 pos)
        {
            if (!Application.isPlaying) return null;

            if (Particolresurses.ItemsDictionary.ContainsKey(ID))
                return CallMee_System(Particolresurses.ItemsDictionary[ID], pos);
            return null;
        }

        private static GameObject CallMee_System(ParticolProduct product, Vector3 pos)
        {
            if (product == null) return null;
            GameObject PrefabToPley = null;
            if (product.IsGrope)
            {
                TList<GameObject> Lists = new TList<GameObject>();
                for (int i = 0; i < product.Prefab_Grope.Count; i++)
                {
                    if (product.Prefab_Grope[i] != null)
                        Lists += product.Prefab_Grope[i];
                }
                if (Lists.IsEnpty()) throw new NullReferenceException(product.Name + "'s grope prefab NotFound"); 
                PrefabToPley = Lists.RandomItem;
            }
            else
            {
                
                if (product.Prefab == null) throw new NullReferenceException(product.Name + "'s prefab NotFound");
                PrefabToPley = product.Prefab;
            }
            if (PrefabToPley == null) throw new NullReferenceException(product.Name + "'s prefab NotFound");

            GameObject ll = GameObject.Instantiate(PrefabToPley);
            ll.transform.position = pos;
            MonoBehaviour.DontDestroyOnLoad(ll);
            return ll;
        }

    }
}
