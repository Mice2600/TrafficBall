using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using SystemBox;
using SystemBox.Simpls;
using UnityEngine;

public class PathBall : Ball
{
    public PlaceController spinPath => _spinPath??= GameObject.FindObjectOfType<PlaceController>();
    private PlaceController _spinPath;

    public float PathTime
    {
        get => _PathTime;
        set
        {
            transform.position = spinPath.CirclePath.path.GetPointAtTime(value);
            _PathTime = value;
        }
    }
    private float _PathTime;
    public PathBall NormalBihaind
    {
        get
        {
            PathBall Bihaind = null;
            if (spinPath.PathBalls.Count > 1)
            {
                Bihaind = spinPath.PathBalls.PreviousOf(this);
                if (TMath.Distance(spinPath.CirclePath.path.GetPointAtTime(PathTime + spinPath.BallSize * 2), spinPath.CirclePath.path.GetClosestPointOnPath(Bihaind.transform.position)) > .6f) Bihaind = null;
            }
            return Bihaind;
        }
    }
    public PathBall NormalForward
    {
        get
        {
            PathBall Forward = null;
            if (spinPath.PathBalls.Count > 1)
            {
                Forward = spinPath.PathBalls.NextOf(this);
                if (TMath.Distance(spinPath.CirclePath.path.GetPointAtTime(PathTime - spinPath.BallSize * 2), spinPath.CirclePath.path.GetClosestPointOnPath(Forward.transform.position)) > .6f) Forward = null;
            }
            return Forward;
        }
    }
    private bool isInPlace 
    {
        get => _isInPlace;
        set 
        {
            if (value && !_isInPlace) AudioPlayer.PlayAudio("Tik");
            _isInPlace = value;
        }
    }
    private bool _isInPlace = true;
    float SpeedForce;
    public void UpdateAction()
    {
        PathBall Bihaind = null;
        PathBall forward = null;
        if (spinPath.PathBalls.First != this) Bihaind = spinPath.PathBalls.PreviousOf(this);
        if (spinPath.PathBalls.Last != this) forward = spinPath.PathBalls.NextOf(this);
        
        Move();


        void Move()
        {
            if (Bihaind == null) 
            {

                transform.position = Vector3.MoveTowards(transform.position, spinPath.CirclePath.path.GetPointAtTime(PathTime + .02f), spinPath.Speed * TimeControll.deltaTime);
                PathTime = spinPath.CirclePath.path.GetClosestTimeOnPath(transform.position);
                return; 
            }


            PathBall LoopForward = spinPath.PathBalls[spinPath.PathBalls.IndexOf(this) + 1];
            PathBall LoopBihaind = spinPath.PathBalls[spinPath.PathBalls.IndexOf(this) - 1];



            PathBall NearOne = null;
            float DisNE = 999;
            for (int i = 0; i < spinPath.PathBalls.Count; i++)
            {
                if (Vector3.Distance(spinPath.PathBalls[i].transform.position, transform.position) < DisNE)
                {
                    DisNE = Vector3.Distance(spinPath.PathBalls[i].transform.position, transform.position);
                    NearOne = spinPath.PathBalls[i];
                }
            }

            float Speed = spinPath.Speed * TimeControll.deltaTime;
            if (Vector3.Distance(NearOne.transform.position, transform.position) < .9f) Speed *= 5f;
            SpeedForce += Time.deltaTime / 3;
            Speed += SpeedForce;
            MoveForward();

            PathTime = spinPath.CirclePath.path.GetClosestTimeOnPath(transform.position);



            void MoveForward()
            {
                float Dis = Vector3.Distance(transform.position, spinPath.CirclePath.path.GetPointAtTime(LoopBihaind.PathTime - spinPath.BallSize * 2));
                isInPlace = Dis <.3f;
                if (Dis < .3f) SpeedForce = 0f;
                if (Dis > 2f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, spinPath.CirclePath.path.GetPointAtTime(PathTime + .15f), Speed);
                }
                else transform.position = Vector3.MoveTowards(transform.position, spinPath.CirclePath.path.GetPointAtTime(LoopBihaind.PathTime - spinPath.BallSize * 2), Speed);
                
            }
        }
    }
    public void PushForward() 
    {
    
    }
    public void PushBack() { }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(spinPath.CirclePath.path.GetPointAtTime(PathTime + spinPath.BallSize * 2), .1f);
        Gizmos.DrawSphere(spinPath.CirclePath.path.GetPointAtTime(PathTime - spinPath.BallSize * 2), .1f);
    }
}

