using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

[System.Serializable]
public struct Content
{
    public int Number;
    public int AlgaritmNumber => conciliate.NumberToAlgaritim(Number);
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is not Content) return false;
        if ((obj as Content?).Value.Number != Number) return false;
        return true;
    }
    public override int GetHashCode() => base.GetHashCode();
    public static bool operator !=(Content a, Content d) => !a.Equals(d);
    public static bool operator ==(Content a, Content d) => a.Equals(d);
    public static  implicit operator int(Content a) => a.Number;
    public static  implicit operator Content(int a) => new Content {Number = a };
}
