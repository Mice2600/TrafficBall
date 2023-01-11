using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemBox;
namespace SystemBox.UI
{


    public class HidenEngine 
    {
    
    
    public class UIVewEngine : MonoBehaviour
    {
        public virtual void Set(UIView.UIViewBehavior ViewBehavior, float WiteBiforStart)
        {
            uIView = GetComponent<UIView>();
            this.ViewBehavior = ViewBehavior;
            AnimetedTime = -WiteBiforStart;
            UIView.Move(0, uIView, ViewBehavior);
        }
        public UIView uIView;
        public UIView.UIViewBehavior ViewBehavior;
        private protected float AnimetedTime;
        private void Update() => MoveUpdate();
        protected virtual void MoveUpdate()
        {
            if (AnimetedTime <= 1 && AnimetedTime >= 0)
            {
                UIView.Move(AnimetedTime, uIView, ViewBehavior);
                AnimetedTime += Time.deltaTime * ViewBehavior.Speed;
                if (AnimetedTime >= 1f && Application.isPlaying)
                {
                    OnFinish();
                    return;
                }
            }
            else
            {
                AnimetedTime += Time.deltaTime;
            }


        }
        public virtual void OnFinish()
        {
            DestroyImmediate(this);
            UIView.Move(1, uIView, ViewBehavior);
            uIView.OnFineshed(ViewBehavior);
        }
    }


#if UNITY_EDITOR
    public class UIVewEngineEditor : UIVewEngine
    {
        public override void Set(UIView.UIViewBehavior ViewBehavior, float WiteBiforStart)
        {
            base.Set(ViewBehavior, WiteBiforStart);
            if (!Application.isPlaying) UnityEditor.EditorApplication.update += MoveUpdate;

        }
        protected override void MoveUpdate()
        {
            base.MoveUpdate();


            if (AnimetedTime >= 1.3f)
            {
                OnFinish();
                return;
            }

            if (!Application.isPlaying)
            {
                if (UnityEditor.Selection.activeGameObject != gameObject)
                {
                    OnFinish();
                    return;
                }
            }

        }
        public override void OnFinish()
        {
            if (AnimetedTime >= 1.3f)
            {
                DestroyImmediate(this);
                uIView.ResetToEngine();
                UIView.Move(1, uIView, ViewBehavior);
                if (!Application.isPlaying) UnityEditor.EditorApplication.update -= MoveUpdate;
            }
        }
    }
#endif
    }
}