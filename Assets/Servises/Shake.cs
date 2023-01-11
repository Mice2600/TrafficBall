using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
namespace ProjectSettings 
{
    public partial class ProjectSettings 
    {
        [FoldoutGroup("ShakeWewes")]
        public List<ShakeWewe> ShakeWewes;

    }
}*/

[System.Serializable]
public struct ShakeWewe 
{
    public static ShakeWewe Tik => new ShakeWewe {  Duration = 0.05f, Magnitude = 0.03f};
    public static ShakeWewe SmoseWewe => new ShakeWewe {  Duration = 0.1f, Magnitude = 0.03f};
    public static ShakeWewe BigWewe => new ShakeWewe {  Duration = 0.1f, Magnitude = 0.05f};

    public string ID;
    [HorizontalGroup]
    public float Duration, Magnitude;
}

public class Shake : MonoBehaviour
{

    public void ShakeWeve(ShakeWewe Value) 
    {
        ShakeWeve(Value.Duration, Value.Magnitude);
    }
    /*
    public void ShakeWeve(string ID) 
    {
        for (int i = 0; i < ProjectSettings.ProjectSettings.Mine.ShakeWewes.Count; i++)
        {
            if (ProjectSettings.ProjectSettings.Mine.ShakeWewes[i].ID == ID) 
            {
                ShakeWeve(ProjectSettings.ProjectSettings.Mine.ShakeWewes[i].Duration, ProjectSettings.ProjectSettings.Mine.ShakeWewes[i].Magnitude);
                break;
            }
        }
    }*/

    public void ShakeWeve(float duration, float magnitude) 
    {
        StartCoroutine(ShakeWeveCoroutine(duration, magnitude));
    }
    private IEnumerator ShakeWeveCoroutine(float duration, float magnitude) 
    {
        Vector3 orginalpos = transform.localPosition;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float Y = Random.Range(-1f,1f) * magnitude;
            float Z = Random.Range(-1f,1f) * magnitude;
            transform.localPosition = orginalpos + new Vector3(x, Y, Z);
            
           elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = orginalpos;
    }
}
