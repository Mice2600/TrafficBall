using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SingletonObject<T> : MonoBehaviour where T : System.Enum
{
    public T Links;
    public static Transform Get(T linc)
    {
        if (!SystemBox.Simpls.Comand.IsColled("Get"))
        {
            keyValuePairs = new Dictionary<T, Transform>();
            GameObject.FindObjectsOfType<SingletonObject<T>>(true).ToList().ForEach(delegate (SingletonObject<T> d)
            {
                keyValuePairs.Add(d.Links, d.transform);
            });
        }
        if (!keyValuePairs.ContainsKey(linc)) 
            throw SystemBox.Tools.ExceptionThrow(new System.Exception($"Objekt With {linc} not found"), 2);
        return keyValuePairs[linc];
    }
    private static Dictionary<T, Transform> keyValuePairs = new Dictionary<T, Transform>();
}
