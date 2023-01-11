using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Servises
{
    public interface RePlaceController
    {
        public bool TrayUp();
        public bool TrayDown();
    }

    public class RePlaceContents : MonoBehaviour
    {
        private ScrollRect scrollRect
        {
            get
            {
                if (_scrollRect == null)
                {
                    Transform ToTest = transform;
                    for (int i = 0; i < 20; i++)
                    {
                        if (ToTest.TryGetComponent<ScrollRect>(out ScrollRect wordContent))
                        {
                            _scrollRect = wordContent;
                            break;
                        }
                        ToTest = ToTest.parent;
                        if (ToTest == null) break;
                    }
                }
                return _scrollRect;
            }
        }
        private ScrollRect _scrollRect;
        private RePlaceController wordBaseViwe
        {
            get
            {
                if (_wordBaseViwe == null)
                {
                    Transform ToTest = transform;
                    for (int i = 0; i < 20; i++)
                    {
                        if (ToTest.TryGetComponent<RePlaceController>(out RePlaceController wordContent))
                        {
                            _wordBaseViwe = wordContent;
                            break;
                        }
                        ToTest = ToTest.parent;
                        if (ToTest == null) break;
                    }
                }
                return _wordBaseViwe;
            }
        }
        private RePlaceController _wordBaseViwe;

        public VerticalLayoutGroup VerticalLayoutGroup;
        public float Dddd;
        private void Update()
        {
            Dddd = (int)(scrollRect.verticalNormalizedPosition * 100f);
            if (Input.GetMouseButton(0)) return;
            if (scrollRect.content.childCount < 20) return;
            if (Dddd > 70)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (!wordBaseViwe.TrayUp()) break;
                    scrollRect.content.GetChild(scrollRect.content.childCount - 1).SetAsFirstSibling();
                    scrollRect.content.position += new Vector3(0, scrollRect.content.GetChild(0).GetComponent<RectTransform>().rect.height + (VerticalLayoutGroup.spacing), 0);

                }
            }
            if (Dddd < 30)
            {
                for (int i = 0; i < 1; i++)
                {
                    if (!wordBaseViwe.TrayDown()) break;
                    scrollRect.content.GetChild(0).SetAsLastSibling();
                    scrollRect.content.position -= new Vector3(0, scrollRect.content.GetChild(0).GetComponent<RectTransform>().rect.height + (VerticalLayoutGroup.spacing), 0);
                }
            }
        }
        [Button]
        public void TrayUp()
        {
            scrollRect.content.GetChild(scrollRect.content.childCount - 1).SetAsFirstSibling();
            scrollRect.content.position += new Vector3(0, scrollRect.content.GetChild(0).GetComponent<RectTransform>().rect.height + (VerticalLayoutGroup.spacing), 0);
        }
        [Button]
        public void TrayDown()
        {
            scrollRect.content.GetChild(0).SetAsLastSibling();
            scrollRect.content.position -= new Vector3(0, scrollRect.content.GetChild(0).GetComponent<RectTransform>().rect.height + (VerticalLayoutGroup.spacing), 0);
        }
    }
}