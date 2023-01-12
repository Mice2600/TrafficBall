using PathCreation;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SystemBox;
using SystemBox.Simpls;
using UnityEngine;

public class PlaceController : MonoBehaviour
{
    public float Speed;
    [Range(0f, 0.1f)]public float BallSize = 0.01f;


    public LoopList<PathBall> PathBalls = new LoopList<PathBall>();

    public TList<MonoBehaviour> StopSpeeningPbjects => _StopSpeeningPbjects??=  new TList<MonoBehaviour>();
    private TList<MonoBehaviour> _StopSpeeningPbjects;
    
    
    public System.Action<TList<Content>, Content> OnMarge;

    [Required]
    public PathCreator CirclePath;


    private void Awake()
    {
        PathBalls = new LoopList<PathBall>();
    }

    private float _PerTime;
    protected void Update()
    {
         //PathBalls.Rotate(true).ForEach(a => a.Gravitation());
        PathBalls.ForEach(a => a.UpdateAction());
        _PerTime += Time.deltaTime * 1.4f;
        if (_PerTime > 1) 
        {
            _PerTime = 0;
            CheackSides();
        }
    }
    

    public bool TryMargeNewContent(GameObject NewBall) 
    {
        _PerTime = 0;
        if (!TrayMargeForFirst()) 
        {
            if (PathBalls.Count >= 16) return false;
            AddToList(); 
        }

        PathBall NewPath = NewBall.GetComponent<PathBall>();
        
        NewPath.PathTime = CirclePath.path.GetClosestTimeOnPath(NewBall.transform.position);
        //FixLists();
        return true;

        bool TrayMargeForFirst()
        {
            

            if (PathBalls.Count == 0) return false;
            Vector3 NearPos = CirclePath.path.GetClosestPointOnPath(NewBall.transform.position);

            PathBall NearOne = PathBalls[0];
            float DisNE = 999;
            for (int i = 0; i < PathBalls.Count; i++)
            {
                if (Vector3.Distance(PathBalls[i].transform.position, NearPos) < DisNE) 
                {
                    DisNE = Vector3.Distance(PathBalls[i].transform.position, NearPos);
                    NearOne = PathBalls[i];
                }
            }
            if (DisNE > .5f) return false;

            if (conciliate.TrayMarge(new TList<Content>(NewBall.GetComponent<ContentObject>().Content, NearOne.Content), out Content NEwContent)) 
            {
                OnMarge?.Invoke(new TList<Content>(NewBall.GetComponent<ContentObject>().Content, NearOne.Content), NEwContent);
                GameObject da = Instantiate(ProjectSettings.ProjectSettings.Mine.GetNuberBallPrefab(NEwContent));
                da.GetComponent<PathBall>().Content = NEwContent;
                da.transform.position = NearOne.transform.position;
                PathBalls[PathBalls.IndexOf(NearOne)] = da.GetComponent<PathBall>();
                Destroy(NearOne.gameObject);
                Destroy(NewBall);
                NewBall = da;
                return true;
            }
            
            
            return false;
        }
        

        void AddToList() 
        {
            if (PathBalls.Count == 0) 
            {
                PathBalls.Add(NewBall.GetComponent<PathBall>());
                return;
            }
            Vector3 NearPos = CirclePath.path.GetClosestPointOnPath(NewBall.transform.position);

            PathBall NearOne = null;
            float DisNE = 999;
            for (int i = 0; i < PathBalls.Count; i++)
            {
                if (Vector3.Distance(PathBalls[i].transform.position, NearPos) < DisNE)
                {
                    DisNE = Vector3.Distance(PathBalls[i].transform.position, NearPos);
                    NearOne = PathBalls[i];
                }
            }


            
            float Bihaindis = TMath.Distance(NewBall.transform.position, CirclePath.path.GetPointAtTime(NearOne.PathTime - .01f));
            float fordisdis = TMath.Distance(NewBall.transform.position, CirclePath.path.GetPointAtTime(NearOne.PathTime + .01f));
            if (Bihaindis < fordisdis) //orqada
            {
                if (NearOne == PathBalls.First) PathBalls.AddTo(1, NewBall.GetComponent<PathBall>());
                else if (NearOne == PathBalls.Last) PathBalls.Add(NewBall.GetComponent<PathBall>());
                else PathBalls.AddTo(PathBalls.IndexOf(NearOne) + 1, NewBall.GetComponent<PathBall>()); 

            } else // oldinda
            {
                if (NearOne == PathBalls.Last) { PathBalls.Add(NewBall.GetComponent<PathBall>()); }
                else if(NearOne == PathBalls.First) { PathBalls.AddTo(PathBalls.IndexOf(NearOne), NewBall.GetComponent<PathBall>());  }
                else { PathBalls.AddTo(PathBalls.IndexOf(NearOne) + 1, NewBall.GetComponent<PathBall>());  }
            }
        }
    }
    

    public void CheackSides() 
    {
        for (int i = 0; i < PathBalls.Count; i++)//look fo treoo
        {
            if (ChakeoneResultat(i, out List<PathBall> resultats) && resultats.Count == 3) 
            {
                Marge(resultats);
                return;
            }
        }
        for (int i = 0; i < PathBalls.Count; i++)//look fo Dowoo
        {
            if (ChakeoneResultat(i, out List<PathBall> resultats)) 
            {
                Marge(resultats);
                return;
            }
        }

        void Marge(List<PathBall> resultats) 
        {
            TList<Content> contents = new TList<Content>();
            resultats.ForEach(a => contents.Add(a.Content));
            conciliate.TrayMarge(contents, out Content NEwContent);

            OnMarge?.Invoke(contents, NEwContent);

            Vector3 SenterPos = resultats[0].transform.position;
            resultats.ForEach(a => SenterPos += a.transform.position);
            SenterPos /= resultats.Count;
            resultats.ForEach(a => { PathBalls.Remove(a); Destroy(a.gameObject); });

            GameObject InN = Instantiate(ProjectSettings.ProjectSettings.Mine.GetNuberBallPrefab(NEwContent), SenterPos, Quaternion.identity);
            InN.GetComponent<PathBall>().Content = NEwContent;
            TryMargeNewContent(InN);
        }


        
        bool ChakeoneResultat(int Index, out List<PathBall> DLis) 
        {
            DLis = new List<PathBall>();
            
            PathBall NormalBihaind = PathBalls[Index].NormalBihaind;
            if (NormalBihaind != null)
                if (NormalBihaind.Content == PathBalls[Index].Content) DLis.Add(NormalBihaind);
            
            DLis.Add(PathBalls[Index]);
            
            PathBall NormalForward = PathBalls[Index].NormalForward;
            if (NormalForward != null)
                if (NormalForward.Content == PathBalls[Index].Content) DLis.Add(NormalForward);

            if (DLis.Count > 1) return true;
            DLis = new List<PathBall>();
            return false;
        }
    }
}


