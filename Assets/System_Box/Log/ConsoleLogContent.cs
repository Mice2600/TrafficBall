using SystemBox;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ConsoleLogContent : MonoBehaviour
{
    public Vector2 ScreenPosEditMode;
    public TextMeshProUGUI TextMeshProUGUI;
    private Image Back 
    {
        get
        {
            if (_Back == null) 
            {
                GameObject d = new GameObject("Shadow");
                d.transform.SetParent(transform.parent);
                d.transform.SetSiblingIndex(transform.GetSiblingIndex());
                d.hideFlags = HideFlags.HideAndDontSave;
                d.AddComponent<RectTransform>();
                d.AddComponent<Image>().color = new Color(0.09411766f, 0.1058824f, 0.1254902f, 1);
                if(Application.isPlaying)d.AddComponent<Button>().onClick.AddListener(() => Destroy(gameObject));
                _Back = d.GetComponent<Image>();
            }
            return _Back;
        }
    }
    private Image _Back;
    private void Start()
    {
        if (Application.isPlaying)Destroy(gameObject, 3);
        if (Application.isPlaying)transform.position = Camera.allCameras[0].ViewportToScreenPoint(ScreenPosEditMode);
        
        

    }
    private void Update()
    {
        try
        {
            Vector2 ds = TextMeshProUGUI.GetRenderedValues(true) + Vector2.one * 10;
            Back.rectTransform.offsetMax = ds / 2;
            Back.rectTransform.offsetMin = -ds / 2;
            Back.rectTransform.position = transform.position;
        }
        catch (System.Exception)
        {

        }
        
    }
    private void OnDestroy()
    {
        if (Back != null) Back.gameObject.ToDestroy();
    }
}
