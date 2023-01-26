using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowZero : MonoBehaviour
{
    public float Speed = 15f;
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, Time.deltaTime * Speed);
    }
}
//