




using UnityEngine;
public class ArrayNameAttribute : PropertyAttribute
{
    public readonly string[] names;
    public ArrayNameAttribute(params string[] names){this.names = names;}
}








