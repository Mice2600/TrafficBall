using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Servises.SmartText
{
    public class SmartSizer : MonoBehaviour
    {
        [SerializeField]
        private float OfsetSize = 2;
        [Required]
        public TMP_Text NText;
        private RectTransform rectTransform => _rectTransform ??= GetComponent<RectTransform>();
        private RectTransform _rectTransform;
        private protected virtual void Update()
        {
            FixtSize();
        }

        private protected void FixtSize()
        {
            Vector3 oldpos = transform.position;
            Vector2 ds = NText.GetRenderedValues(true);
            
            if (ds.y < 0) ds = new Vector2(0,0);
            ds *= 1.15f;
            rectTransform.offsetMax = ds / OfsetSize;
            rectTransform.offsetMin = -ds / OfsetSize;
            transform.position = oldpos;
            //transform.position = NText.transform.position;
        }

    }
}