using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

namespace ProjectSettings
{
    public partial class ProjectSettings
    {
        [Required]
        public GameObject MargeBallPlayPrefab;
    }
}

public class MargeBallPlay : MonoBehaviour
{



    public static List<MareEfectBall> MargeBalls = new List<MareEfectBall>();
    public static void Play(TList<Ball> Olds, Ball News)
    {
        if (MargeBalls == null) MargeBalls = new List<MareEfectBall>();

        int GetIndex()
        {
            for (int i = 0; i < MargeBalls.Count; i++)
                if (MargeBalls[i].gameObject.activeSelf == false)
                    return i;
            MargeBalls.Add(Instantiate(ProjectSettings.ProjectSettings.Mine.MargeBallPlayPrefab).GetComponent<MareEfectBall>());
            return MargeBalls.Count - 1;
        }

        for (int C = 0; C < Olds.Count; C++)
        {
            int I = GetIndex();
            MargeBalls[I].gameObject.SetActive(true);
            MargeBalls[I].transform.position = Olds[C].transform.GetChild(0).position;
            MargeBalls[I].Content = Olds[C].Content;
            MargeBalls[I].Sphere.material = new Material(Olds[C].SphereRenderer.material);
            MargeBalls[I].Set(News.transform, News.SphereRenderer.material.GetColor("_GradientColorTwo"));
        }
    }


    private void Start()
    {
        FindObjectOfType<PlaceController>().OnMarge += Play;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
