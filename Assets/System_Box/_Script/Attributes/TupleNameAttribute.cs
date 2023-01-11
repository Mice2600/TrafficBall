using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
[Conditional("UNITY_EDITOR")]
public class TupleNameAttribute: PropertyAttribute
{
    public readonly string[] names;
    public TupleNameAttribute(params string[] names){this.names = names;}
}

