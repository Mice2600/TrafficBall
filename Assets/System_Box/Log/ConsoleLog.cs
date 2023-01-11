using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemBox.Engine;
using SystemBox;
using TMPro;
using Sirenix.OdinInspector;
using System.Globalization;
using System;
using UnityEngine.UI;

public class ConsoleLog : MonoBehaviour
{

    public string Massage;
    private static ConsoleLog consoleLog 
    {
        get 
        {
            if (_consoleLog == null) _consoleLog = new GameObject("Log").AddComponent<ConsoleLog>();
            return _consoleLog;
        }
    }
    private static ConsoleLog _consoleLog;
    public static void Log(string Massage)
    {
        consoleLog.Massage = Massage;
        consoleLog.TimeToCount = 3f;
    }

    float TimeToCount;
    private void OnGUI()
    {
        TimeToCount -= Time.deltaTime;
        if (TimeToCount < 0) return;
        if (GUI.Button(new Rect((Screen.width / 2) - 100, Screen.height / 10, 200, 30), Massage)) 
        {
            TimeToCount = -1; 
        }
    }




}
