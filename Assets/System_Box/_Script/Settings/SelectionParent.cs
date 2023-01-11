using UnityEngine;
using Sirenix.OdinInspector;
[HideMonoScript]
[SelectionBase]
public class SelectionParent : MonoBehaviour {
    public void HideFLAG() => hideFlags = HideFlags.HideInInspector;
}
