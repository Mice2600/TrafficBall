using PathCreation;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

public class CurrentContentSystem : MonoBehaviour
{
    public ContentObject ContentObject;
    private NextContentSystem NextContentSystem => _NextContentSystem ??= FindObjectOfType<NextContentSystem>();
    private NextContentSystem _NextContentSystem;
    private PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    private PlaceController _PlaceController;

    [Required]
    public PathCreator WayPath;
    private void Start()
    {
        CreatNew(NextContentSystem.NewContentAlgaritm());
    }

    private void Update()
    {
        
    }

    public void Shot()
    {
        if (ContentObject == null) return;
        MargeBall En = ContentObject.gameObject.AddComponent<MargeBall>();
        En.PlaceController = PlaceController;
        En.WayPath = WayPath;
        En.OnFinsh += Onfinsh;
        ContentObject = null;
        void Onfinsh(bool a) 
        {
            if (!a) return;
            CreatNew(NextContentSystem.ContentObject.Content);
            NextContentSystem.CreatNew();
        }
    }
    public void Replace() 
    {
        if (this.ContentObject == null) return;

        Content A = this.ContentObject.Content;
        Content B = NextContentSystem.ContentObject.Content;
        NextContentSystem.CreatNew(A);
        CreatNew(B);
    }

    public void CreatNew(Content content) 
    {
        if (this.ContentObject != null) Destroy(this.ContentObject.gameObject);
        GameObject InN = Instantiate(ProjectSettings.ProjectSettings.Mine.GetNuberBallPrefab(content));
        this.ContentObject = InN.GetComponent<ContentObject>();
        this.ContentObject.Content = content;
        InN.transform.position = transform.position;
    }

}
public class MargeBall : MonoBehaviour 
{
    public PlaceController PlaceController;
    public PathCreator WayPath;
    private float Speed = 0f;
    private float PathTime;
    private bool IsDone;

    public System.Action<bool> OnFinsh;

    
    private void Update()
    {
        if (IsDone) return;
        Speed += Time.deltaTime * 10f;
        PathTime += Speed * Time.deltaTime;
        if (PathTime > 1f) 
        {
            PathTime = 1f;
            IsDone = true;
            onFinish();
        }
        transform.position = WayPath.path.GetPointAtTime(PathTime);
    }
    private void onFinish() 
    {
        Destroy(this);
        if (!PlaceController.TryMargeNewContent(gameObject)) { OnFinsh?.Invoke(false); return;  }
        OnFinsh?.Invoke(true);
    }

}