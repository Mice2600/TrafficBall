using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SpinPath : MonoBehaviour
{
    public float Size;
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Size);
    }
    
    public Vector3 GetNearPoint(Vector3 Point) 
    {
        Point.y = transform.position.y;
        transform.LookAt(Point);
        return transform.position + transform.forward * Size;
    }
    public float GetTimeByNearPoint(Vector3 Point) 
    {
        Point.y = transform.position.y;
        transform.LookAt(Point);
        return  transform.rotation.eulerAngles.y / 360f;
    }
    public Vector3 GetTimePoint(float Time) 
    {
        Time = Time % 1f;
        transform.rotation = Quaternion.identity;
        transform.Rotate(0, 360f * Time, 0);
        return transform.position + transform.forward * Size;
    }
}
