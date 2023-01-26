using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    
    void Start()
    {
        FindObjectOfType<CurrentContentSystem>().OnShot += (i) => { SystemBox.AudioPlayer.PlayAudio("smash"); };
        FindObjectOfType<PlaceController>().OnMarge +=
        (list, a) =>
        {
            for (int i = 1; i < list.Count; i++) SystemBox.AudioPlayer.PlayAudio("Crash");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
