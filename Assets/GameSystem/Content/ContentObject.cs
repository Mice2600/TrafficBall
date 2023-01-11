using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContentObject : MonoBehaviour
{
    public Content Content 
    {
        get => _Content;
        set 
        {
            _Content = value;
            OnValueChanged?.Invoke(_Content);
        }
    }
    private Content _Content;
    public System.Action<Content> OnValueChanged;
}
