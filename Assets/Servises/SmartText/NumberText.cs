using Servises.SmartText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberText : ContentText
{
    public override string OnValueChanged(Content Object) => Object.Number.ToString();
}
