using Servises;
using Servises.SmartText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacity : SmartText
{
    PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    PlaceController _PlaceController;
    public override string MyText => PlaceController.PathBalls.Count + "/"+ PlaceController.Capacity;
}
