using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

public class PlayBrokenBall : MonoBehaviour
{
    void Start()
    {
        return;
        FindObjectOfType<PlaceController>().OnMarge += (TList<Ball> Nlist, Ball Nc) =>
        {
            for (int i = 0; i < Nlist.Count; i++)
                BrokeBoll.Play(Nlist[i].SphereRenderer.material, Nlist[i].transform.position);
        };
    }

}
