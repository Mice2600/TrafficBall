using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutulior : MonoBehaviour
{
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutulior") == 0)
        {
            StartCoroutine(WAiter());
            IEnumerator WAiter() 
            {
                TimeControll.TimeStoppers.Add(this);
                while (true) 
                {
                    yield return null;
                    if (Input.GetMouseButton(0)) 
                    {
                        TimeControll.TimeStoppers.Remove(this);
                        Destroy(gameObject);
                        PlayerPrefs.SetInt("Tutulior", 1);
                    }
                }
            }
        }
        else Destroy(gameObject);
    }

    
}
