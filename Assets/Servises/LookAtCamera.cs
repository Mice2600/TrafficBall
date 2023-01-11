using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [Button]
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
