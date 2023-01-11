using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;


namespace ProjectSettings 
{
    public partial class ProjectSettings 
    {
        public GameObject GetAlgaritmBallPrefab(int Algaritm) => new LoopList<GameObject>(Balls)[Algaritm];
        public GameObject GetNuberBallPrefab(int Number) => GetAlgaritmBallPrefab(conciliate.NumberToAlgaritim(Number));
        [SerializeField]private List<GameObject> Balls;
    }
}

public class Ball : ContentObject
{
        
}
