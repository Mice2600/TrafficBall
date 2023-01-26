using PathCreation;
using Sirenix.OdinInspector;
using System.Collections;
using SystemBox;
using UnityEngine;

public class CurrentContentSystem : MonoBehaviour
{
    public ContentObject ContentObject;
    public NextContentSystem NextContentSystem => _NextContentSystem ??= FindObjectOfType<NextContentSystem>();
    private NextContentSystem _NextContentSystem;
    public PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    private PlaceController _PlaceController;

    public System.Action<PathBall> OnShot;

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
        OnShot?.Invoke(ContentObject.GetComponent<PathBall>());
        En.PlaceController = PlaceController;
        En.WayPath = WayPath;
        En.OnFinsh += Onfinsh;
        ContentObject = null;
        void Onfinsh(bool a) 
        {
            if (!a) 
            {
                FindObjectOfType<GameOverSystem>().Play();
                return;
            }
            CreatNew(NextContentSystem.ContentObject.Content);
            NextContentSystem.CreatNew();
        }
    }
    public void Replace() 
    {
        if (this.ContentObject == null) return;
        AudioPlayer.PlayAudio("Relode");
        Content A = this.ContentObject.Content;
        Content B = NextContentSystem.ContentObject.Content;
        NextContentSystem.CreatNew(A);
        CreatNew(B);
    }

    public void CreatNew(Content content) 
    {
        if (this.ContentObject != null) Destroy(this.ContentObject.gameObject);
        GameObject InN = Instantiate(ProjectSettings.ProjectSettings.Mine.BallPrefab);
        InN.GetComponent<Ball>().SphereRenderer.material = new Material(ProjectSettings.ProjectSettings.Mine.GetAlgaritmBallMaterial(content));
        InN.GetComponent<ContentObject>().Content = content;
        InN.transform.position = transform.position;
        StartCoroutine(MoweToMee());

        IEnumerator MoweToMee()
        {
            InN.transform.position = WayPath.path.GetPointAtTime(0);
            while (true)
            {
                InN.transform.position = Vector3.MoveTowards(InN.transform.position, transform.position, Time.deltaTime * 30f);
                if (InN.transform.position == transform.position) break;
                yield return null;
            }
            this.ContentObject = InN.GetComponent<ContentObject>();
        }

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
    private void Start()
    {
        PathTime = WayPath.path.GetClosestTimeOnPath(transform.position);
    }

    private void Update()
    {
        if (IsDone) return;
        Speed += TimeControll.deltaTime * 20f;
        PathTime += Speed * TimeControll.deltaTime;
        if (PathTime >= 0.97f) 
        {
            PathTime = 0.97f;
            IsDone = true;
            onFinish();
        }
        transform.position = WayPath.path.GetPointAtTime(PathTime);
    }
    private void onFinish() 
    {
        if (!PlaceController.TryMargeNewContent(gameObject)) { OnFinsh?.Invoke(false); return;  }
        Destroy(this);
        OnFinsh?.Invoke(true);
    }

}