using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNN : MonoBehaviour
{

    public PathCreator CirclePath;
    public float NearTT;
    public float Timess;
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(CirclePath.path.GetClosestPointOnPath(transform.position), transform.position);
        Gizmos.DrawSphere(CirclePath.path.GetDirection(Timess), .2f);
        NearTT = CirclePath.path.GetClosestTimeOnPath(transform.position);
    }
}
