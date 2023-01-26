using Servises.SmartText;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightValume : SmartText
{
    PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    PlaceController _PlaceController;
    public override string MyText => PlaceController.BiggesContent.Number;
}
