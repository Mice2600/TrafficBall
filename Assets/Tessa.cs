using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tessa : MonoBehaviour
{
    public PathCreation.PathCreator Pattt;
    [Button]
    public void TT(List<Transform> error)
    {
        float Off = 1f / error.Count;
        for (int i = 0; i < error.Count; i++)
        {
            error[i].position = Pattt.path.GetPointAtTime(Off * i);
            error[i].rotation = Pattt.path.GetRotation(Off * i);
        }
    }
}
