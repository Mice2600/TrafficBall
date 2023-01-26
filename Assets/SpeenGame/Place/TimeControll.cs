using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeControll 
{
    static TimeControll() 
    {
        TimeStoppers = new List<MonoBehaviour>();
    }
    public static List<MonoBehaviour> TimeStoppers;
    public static float deltaTime 
    {
        get 
        {
            if (TimeStoppers.Count > 0) return 0f;
            return Time.deltaTime;
        }
    } 
    
}
