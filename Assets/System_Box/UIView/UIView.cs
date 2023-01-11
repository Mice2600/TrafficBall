using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using Sirenix.OdinInspector;
using SystemBox;
using SystemBox.Simpls;
using System;
using System.Linq;
using static SystemBox.UI.HidenEngine;

namespace SystemBox.UI
{
    [HideMonoScript]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Canvas))]
    public class UIView : MonoBehaviour
    {
        public CanvasGroup CanvasGroup
        {
            get
            {
                if (_CanvasGroup == null) _CanvasGroup = GetComponent<CanvasGroup>();
                return _CanvasGroup;
            }
        }
        private CanvasGroup _CanvasGroup;




        private enum BehaviourStart { DoNothing, Hide, Show, ShowAnimation }
        [SerializeField]
        [PropertyOrder(-1)]
        private BehaviourStart behaviourStart;


        #region StartPositons

        [PropertyOrder(1), HideLabel, TitleGroup("StartPosition"), HorizontalGroup("StartPosition/Buttons"), GUIColor(0.681f, 0.911f, 1f, 1)]
        public Vector2 OrginalPoint;
        public Vector2 ScreenPosEditMode
        {
            get
            {
                if (Camera.allCameras.Length < 1) return Vector2.zero;
                return Camera.allCameras[0].ViewportToScreenPoint(OrginalPoint);
            }
        }


        [GUIColor(0.6084906f, 0.7546541f, 1f, 1)]
        [HorizontalGroup("StartPosition/Buttons"), Button("Get ->"), PropertyOrder(-1)]
        public void Get() 
        {
            if (Camera.allCameras.Length < 1) { OrginalPoint = Vector2.zero; return; }
            OrginalPoint = Camera.allCameras[0].ScreenToViewportPoint(transform.position); 
        }
        [GUIColor(0.6084906f, 0.7546541f, 1f, 1)]
        [HorizontalGroup("StartPosition/Buttons"), Button(Name = "Reset ^"), PropertyOrder(2)]
        public void Set() => transform.position = ScreenPosEditMode;

        #endregion




        [FoldoutGroup("Show")]
        public UIViewBehavior ShowAnim;
        [FoldoutGroup("Hide")]
        public UIViewBehavior HideAnim;

        private void Start()
        {
            Set();
            isShowing = false;
            isHideing = false;
            if (behaviourStart == BehaviourStart.Hide)
            {
                Move(1, this, HideAnim);
                GetComponent<Canvas>().enabled = !DisebelCanvasOnHide;
                gameObject.SetActive(!DisebelObjecrtOnHide);
                isHideing = true;
            }
            else if (behaviourStart == BehaviourStart.Show)
            {
                GetComponent<Canvas>().enabled = true;
                gameObject.SetActive(true);
                Move(1, this, ShowAnim);
                isShowing = true;
            }
            else if (behaviourStart == BehaviourStart.ShowAnimation)
            {
                GetComponent<Canvas>().enabled = true;
                gameObject.SetActive(true);
                Move(0, this, ShowAnim);

                Show();
            }
        }

        private void Reset()
        {
            Get();

            ShowAnim = new UIViewBehavior();
            HideAnim = new UIViewBehavior();
            ShowAnim.MoveAnimation = new UIViewBehavior.UIAnimation();
            HideAnim.MoveAnimation = new UIViewBehavior.UIAnimation();

            ShowAnim.MoveAnimation.MoveLife = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
            ShowAnim.MoveAnimation.SizeLife = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));
            ShowAnim.MoveAnimation.FridLife = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

            HideAnim.MoveAnimation.MoveLife = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
            HideAnim.MoveAnimation.SizeLife = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
            HideAnim.MoveAnimation.FridLife = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0));
        }
        public void ResetToEngine()
        {
            transform.position = ScreenPosEditMode;
            transform.localScale = Vector3.one;
            CanvasGroup.alpha = 1;
            GetComponents<UIVewEngine>().ToList().ForEach(d => d.OnFinish());
        }

        [BoxGroup("AutoHideAfterShow", showLabel: false), HorizontalGroup("AutoHideAfterShow/1")]
        public bool AutoHideAfterShow;
        [ShowIf("AutoHideAfterShow"), BoxGroup("AutoHideAfterShow", showLabel: false), HorizontalGroup("AutoHideAfterShow/1")]
        public int HideAfterShowTime;

        [TitleGroup("When UIView is hidden disable"), HorizontalGroup("When UIView is hidden disable/1"), SerializeField, LabelText("Objecrt")]
        private bool DisebelObjecrtOnHide;
        [HorizontalGroup("When UIView is hidden disable/1"), SerializeField, LabelText("Canvas")]
        private bool DisebelCanvasOnHide;
        [System.NonSerialized]
        public bool isShowing;
        [System.NonSerialized]
        public bool isHideing;
        public bool isPlaying => Engines != null;
        private UIVewEngine Engines;


        public void ShowMoment() 
        {
            GetComponent<Canvas>().enabled = true;
            gameObject.SetActive(true);
            Move(1, this, ShowAnim);
            isShowing = true;
            isHideing = false;
            if (TryInvoke(ShowAnim.OnFinished, out Exception XX)) Debug.LogException(new Exception("Invalit Show Finsh Event", XX));
        }

        [Button]
        [HideInEditorMode]
        public void Show() => Show(0);
        private void Show(float showafterTime)
        {
            isHideing = false;
            if (isShowing) return;
            isShowing = true;
            GetComponents<UIVewEngine>().ToList().ForEach(d => d.OnFinish());
            GetComponent<Canvas>().enabled = true;
            gameObject.SetActive(true);
            if (TryInvoke(ShowAnim.OnStart, out Exception XX)) Debug.LogException(new Exception("Invalit Show Start Event", XX));

            Engines = gameObject.AddComponent<UIVewEngine>();
            Engines.Set(ShowAnim, showafterTime);

        }
        public void HideMoment() 
        {
            Move(1, this, HideAnim);
            GetComponent<Canvas>().enabled = !DisebelCanvasOnHide;
            gameObject.SetActive(!DisebelObjecrtOnHide);
            isHideing = true;
            isShowing = false;
            if (TryInvoke(HideAnim.OnFinished, out Exception XX)) Debug.LogException(new Exception("Invalit Hide Finsh Event", XX));
        }


        [Button]
        [HideInEditorMode]
        public void Hide() => Hide(0);
        private void Hide(float showafterTime)
        {
            isShowing = false;
            if (isHideing) return;
            isHideing = true;
            GetComponents<UIVewEngine>().ToList().ForEach(d => d.OnFinish());
            GetComponent<Canvas>().enabled = true;
            gameObject.SetActive(true);
            if (TryInvoke(HideAnim.OnStart, out Exception XX)) Debug.LogException(new Exception("Invalit Hide Start Event", XX));

            Engines = gameObject.AddComponent<UIVewEngine>();
            Engines.Set(HideAnim, showafterTime);
        }


        public static bool TryInvoke(UnityEvent unityEvent, out Exception XX)
        {
            XX = null;
            try { unityEvent.Invoke(); }
            catch (Exception X) { XX = X; return true; }
            return false;
        }

        public void OnFineshed(UIViewBehavior Finished)
        {
            if (Finished == ShowAnim)
            {
                if (TryInvoke(ShowAnim.OnFinished, out Exception XX)) Debug.LogException(new Exception("Invalit Show Finsh Event", XX));
                if (AutoHideAfterShow) Hide(HideAfterShowTime);

            }
            else
            {
                if (TryInvoke(HideAnim.OnFinished, out Exception XX)) Debug.LogException(new Exception("Invalit Hide Finsh Event", XX));
                GetComponent<Canvas>().enabled = !DisebelCanvasOnHide;
                gameObject.SetActive(!DisebelObjecrtOnHide);
            }
        }





        public static void Move(float Time, UIView UItransform, UIViewBehavior uIViewBehavior)
        {
            UItransform.transform.position = Vector2.Lerp(
                uIViewBehavior.MoveAnimation.ScreenPosEditMode,
                UItransform.ScreenPosEditMode,
                uIViewBehavior.MoveAnimation.MoveLife.Evaluate(Time));
            UItransform.CanvasGroup.alpha = uIViewBehavior.MoveAnimation.FridLife.Evaluate(Time);
            UItransform.transform.localScale = Vector3.one * uIViewBehavior.MoveAnimation.SizeLife.Evaluate(Time);
        }





        [Serializable]
        [HideLabel]
        public class UIViewBehavior
        {

            private enum ShowType { Animation, Events }

            [ShowInInspector]
            [EnumToggleButtons]
            [HideLabel]
            [OnValueChanged("OnValueChanged")]
            [HorizontalGroup("MEe")]
            private ShowType showType;


#if UNITY_EDITOR
            [Button(Name = "<")]
            [HorizontalGroup("MEe"), PropertyOrder(-1)]
            public void Play()
            {
                if (UnityEditor.Selection.activeGameObject == null) return;
                if (UnityEditor.Selection.activeGameObject.GetComponent<UIView>() == null) return;
                UIView d = UnityEditor.Selection.activeGameObject.GetComponent<UIView>();
                d.ResetToEngine();
                UnityEditor.Selection.activeGameObject.AddComponent<UIVewEngineEditor>().Set(this, 3);
            }
#endif


            private void OnValueChanged()
            {
                if (showType == ShowType.Animation) { ShowAnimation = true; ShowEvents = false; }
                if (showType == ShowType.Events) { ShowAnimation = false; ShowEvents = true; }
            }
            private bool ShowAnimation = true;
            private bool ShowEvents;

            [HorizontalGroup("Events", VisibleIf = "ShowEvents")]
            public UnityEvent OnStart;
            [HorizontalGroup("Events", VisibleIf = "ShowEvents")]
            public UnityEvent OnFinished;

            [ShowIf("ShowAnimation")]
            public UIAnimation MoveAnimation;


            [ShowIf("ShowAnimation")]
            public float Speed = 1;





            [Serializable]
            [HideLabel]
            public class UIAnimation
            {


                [TitleGroup("MovePositon"), HideLabel, HorizontalGroup("MovePositon/Buttons")]
                public Vector2 To = new Vector2(0.5f, -.5f);

#if UNITY_EDITOR
                [Button, HorizontalGroup("MovePositon/Buttons")]
                public void Get()
                {

                    if (UnityEditor.Selection.activeGameObject == null) return;
                    if (UnityEditor.Selection.activeGameObject.GetComponent<UIView>() == null) return;


                    if (Camera.allCameras.Length < 1) To  = Vector2.zero;
                    else To = Camera.allCameras[0].ScreenToViewportPoint(UnityEditor.Selection.activeGameObject.transform.position);
                }
#endif
                public Vector2 ScreenPosEditMode 
                { 
                    get 
                    {
                        if (Camera.allCameras.Length < 1) return Vector2.zero;
                        return Camera.allCameras[0].ViewportToScreenPoint(To);
                    }
                }
                [Curve(0, 0, 1, 1)]
                public AnimationCurve MoveLife;
                [Curve(0, 0, 1, 1)]
                public AnimationCurve SizeLife;
                [Curve(0, 0, 1, 1)]
                public AnimationCurve FridLife;
            }
        }










    }


}