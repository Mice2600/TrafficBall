using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;
using UnityEngine.UI;

public class ContentGropperTrueSorted : MonoBehaviour
{
    public Vector2 Spacing;
    [Range(.2f, 1f)]
    public float ScreenSize = 1;
    [System.NonSerialized]
    public List<Transform> Contents;
    private bool isStarted;
    private void Start()
    {
        if (isStarted) return;
        isStarted = true;

        gameObject.AddComponent<VerticalLayoutGroup>();
        GetComponent<VerticalLayoutGroup>().childControlHeight = false;
        GetComponent<VerticalLayoutGroup>().childControlWidth = false;
        GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
        GetComponent<VerticalLayoutGroup>().spacing = Spacing.y;
        Contents = new List<Transform>();
        //gameObject.AddComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.MinSize;
    }
    private TList<RectTransform> Lines;

    private float Pertime;
    private void Update()
    {
        Pertime += Time.deltaTime;
        if (Pertime > 1f)
        {
            FixPos();
            Pertime = 0;
        }
    }
    public void FixPos()
    {
        //ortiqchalani chiqarvolish
        TList<Transform> Others = new List<Transform>();
        if (Lines == null) Lines = new TList<RectTransform>();
        for (int i = 0; i < Lines.Count; i++)
        {
            Transform Parrent = Lines[i];
            Others.Add(Parrent.Childs());
            while (Parrent.childCount > 0)
            {
                TList<Transform> ds = Parrent.Childs();
                for (int s = 0; s < ds.Count; s++) ds[s].SetParent(null);
            }
        }
        List<Transform> Contents = new List<Transform>(this.Contents);
        this.Contents = new List<Transform>();
        Contents.ForEach(AddNewContent);
    }

    private Transform ConcleateLast(float NextSize)
    {
        if (Lines == null) Lines = new List<RectTransform>();

        for (int i = 0; i < Lines.Count; i++)
        {
            if (Lines[i].childCount > 0) continue;
            Lines[i].SetParent(null);
            Destroy(Lines[i].gameObject);
            Lines.RemoveAt(i);
            i--;
        }

        if (Lines.Count == 0)
        {
            GameObject N = AddNewList();
            Lines.Add(N.GetComponent<RectTransform>());
        }

        Transform Founded = null;
        float NSize = GetSize(Lines.Last);
        if (NSize + NextSize + Lines.Last.GetComponent<HorizontalLayoutGroup>().spacing <= (Screen.width * ScreenSize)) Founded = Lines.Last;    
        if (Founded == null)
        {
            Lines.Add(AddNewList().GetComponent<RectTransform>());
            Founded = Lines.Last;
        }
        return Founded;

        float GetSize(Transform Parrent)
        {
            List<Transform> childes = Parrent.Childs();
            float Ofset = Parrent.GetComponent<HorizontalLayoutGroup>().spacing;
            float size = 0;
            for (int i = 0; i < childes.Count; i++)
            {
                size += childes[i].GetComponent<RectTransform>().rect.width;
                if (i + 1 < childes.Count) size += Ofset;
            }
            return size;
        }

        GameObject AddNewList()
        {
            GameObject NLists = new GameObject("NewList", typeof(RectTransform), typeof(HorizontalLayoutGroup), typeof(ContentSizeFitter));
            NLists.transform.SetParent(transform);
            NLists.GetComponent<HorizontalLayoutGroup>().childControlHeight = false;
            NLists.GetComponent<HorizontalLayoutGroup>().childControlWidth = false;
            NLists.GetComponent<HorizontalLayoutGroup>().childAlignment = TextAnchor.MiddleCenter;
            NLists.GetComponent<HorizontalLayoutGroup>().spacing = Spacing.x;
            return NLists;
        }
    }
    public void AddNewContent(Transform NObject)
    {
        Start();
        Contents.Add(NObject);
        NObject.transform.SetParent(ConcleateLast(NObject.GetComponent<RectTransform>().rect.width));
    }
    public bool RemoveContent(Transform NObject) 
    {
        bool d = Contents.Remove(NObject);
        FixPos();
        return d;
    }
}
