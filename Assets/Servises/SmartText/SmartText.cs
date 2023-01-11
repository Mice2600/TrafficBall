using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
namespace Servises.SmartText
{
    [RequireComponent(typeof(TMP_Text))]
    public abstract class SmartText : MonoBehaviour
    {
        public abstract string MyText { get; }
        public virtual string MargeText => BiforText + MyText + AfterTextText;
        [HideLabel]
        [HorizontalGroup("t")]
        public string BiforText, AfterTextText;
        private protected TMP_Text textMesh => _textMesh ??= GetComponent<TMP_Text>();
        private protected TMP_Text _textMesh;
        protected virtual void Update() => textMesh.text = MargeText;
    }
}