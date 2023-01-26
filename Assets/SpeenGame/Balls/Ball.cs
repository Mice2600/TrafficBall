using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;


namespace ProjectSettings 
{
    public partial class ProjectSettings 
    {
        public Material GetAlgaritmBallMaterial(int Algaritm) => new LoopList<Material>(BallMaterials)[Algaritm];
        [SerializeField]private List<Material> BallMaterials;
        public GameObject BallPrefab;
    }
}

public class Ball : ContentObject
{
    public Renderer SphereRenderer;
}
