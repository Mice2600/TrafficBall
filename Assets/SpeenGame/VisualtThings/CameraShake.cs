using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

public class CameraShake : Shake
{
    private PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    private PlaceController _PlaceController;
    void Start()
    {
        PlaceController.OnMarge += (TList<Content> Nlist, Content Nc) =>
        {
            if (Nlist.Count == 3) base.ShakeWeve(ShakeWewe.SmoseWewe);
            else base.ShakeWeve(ShakeWewe.Tik);//
        };
    }

}
