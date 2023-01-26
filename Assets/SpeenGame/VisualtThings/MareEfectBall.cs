using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class MareEfectBall : ContentObject
{
    [System.NonSerialized]
    public Color NeedColor;
    [System.NonSerialized]
    public Transform NeedTransform;

    
    
    public float Speed;
    public Renderer Sphere;
    public AnimationCurve Sizer;
    public AnimationCurve ColorTimeLine;

    public void Set(Transform FollowTransform, Color FolowColor) 
    {
        OnsizeTime = 0f;
        NeedTransform = FollowTransform;
        NeedColor= FolowColor;
        
    }
    public ParticleSystem Blick;
    private Color StartColor;
    private float OnsizeTime;
    


    void Update()
    {
        OnsizeTime += Time.deltaTime * Speed;
        if (OnsizeTime > .99f) OnsizeTime = 1f;
        if (NeedTransform == null) 
        {
            gameObject.SetActive(false);
            return;
        }
        transform.localScale =Vector3.one * Sizer.Evaluate(OnsizeTime);
        transform.position = Vector3.MoveTowards(transform.position, NeedTransform.position, Speed * Time.deltaTime *2);
        Sphere.material.SetColor("_GradientColorTwo", Color.Lerp(StartColor, NeedColor, ColorTimeLine.Evaluate(OnsizeTime)));
        if (OnsizeTime == 1f) 
        {
            OnsizeTime = 0f;
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        OnsizeTime = 0f;

        Color color = Sphere.material.GetColor("_GradientColorTwo");
        Blick.startColor = color;

        StartColor = color;
    }
    

}
