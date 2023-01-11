using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

public class NextContentSystem : MonoBehaviour
{
    [System.NonSerialized]
    public ContentObject ContentObject;
    private PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    private PlaceController _PlaceController;
    private void Start()
    {
        CreatNew();
    }



    public void CreatNew() 
    {

        CreatNew(NewContentAlgaritm());
    }
    public void CreatNew(Content NContent) 
    {
        if(this.ContentObject != null) Destroy(this.ContentObject.gameObject);
        GameObject InN = Instantiate(ProjectSettings.ProjectSettings.Mine.GetNuberBallPrefab(NContent));
        this.ContentObject = InN.GetComponent<ContentObject>();
        this.ContentObject.Content = NContent;
        InN.transform.position = transform.position;
    }

    public virtual Content NewContentAlgaritm() 
    {
        //return new Content { Number = conciliate.AlgaritimToNumber(Random.Range(1, 8)) };
        TList<int> AlgaritmContents = new TList<int>();
        int Min = 1;
        int Max = 2;
        for (int i = 0; i < PlaceController.PathBalls.Count; i++)
            AlgaritmContents.AddIfDirty(PlaceController.PathBalls[i].Content.AlgaritmNumber);

        if (AlgaritmContents.IsEnpty()) return new Content {  Number = conciliate.AlgaritimToNumber(Random.Range(1, 3)) };
        Min = AlgaritmContents[0];
        Max = AlgaritmContents[0];
        for (int i = 0; i < AlgaritmContents.Count; i++)
        {
            if (Min > AlgaritmContents[i]) Min = AlgaritmContents[i];
            if (Max < AlgaritmContents[i]) Max = AlgaritmContents[i];
        }
        int newContent = Random.Range((Max - 4) - 4, Max - 4);
        if (newContent > Max) newContent = Max;
        if (newContent < 1) newContent = Random.Range(1, 4);
        return new Content { Number = conciliate.AlgaritimToNumber(newContent) };
    }
}
