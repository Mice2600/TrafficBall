using Sirenix.OdinInspector;
using UnityEngine;

public class MergingBallShake : Shake
{
    private PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    private PlaceController _PlaceController;
    [SerializeField, Required]
    private PathBall pathBall;

    private void Start()
    {
        
    }

    float DasTime = 0;

    void Update()
    {
        if (!PlaceController.PathBalls.Contains(pathBall)) return;
        DasTime += Time.deltaTime;
        if (DasTime > .5f) 
        {
            DasTime = 0f;

            PathBall NormalBihaind = pathBall.NormalBihaind;
            if (NormalBihaind != null && NormalBihaind.Content == pathBall.Content) { base.ShakeWeve(ShakeWewe.Tik); return; }
            PathBall NormalForward = pathBall.NormalForward;
            if (NormalForward != null && NormalForward.Content == pathBall.Content) { base.ShakeWeve(ShakeWewe.Tik); return; }

        }
    }
}
