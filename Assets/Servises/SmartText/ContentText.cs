using Servises.SmartText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContentText : SmartText
{
    private void Start()
    {
        ContentObject ToTest = gameObject.GetComponentInParent<ContentObject>();
        ToTest.OnValueChanged += (a) => { MyTextContent = OnValueChanged(a); };
        MyTextContent = OnValueChanged(ToTest.Content);
    }
    public abstract string OnValueChanged(Content Object);
    public override string MyText => MyTextContent;
    private string MyTextContent
    {
        get => _MyText;
        set
        {
            _MyText = value;
            base.Update();
        }
    }
    private string _MyText;
    protected override void Update() { }
}
