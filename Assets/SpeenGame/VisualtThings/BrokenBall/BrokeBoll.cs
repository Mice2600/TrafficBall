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
        public GameObject BrokenBoll;
    }
}
public class BrokeBoll : MonoBehaviour
{
    public static List<BrokeBoll> brokeBolls = new List<BrokeBoll>();
    public static void Play(Material material, Vector3 Pos) 
    {
        if (brokeBolls == null) brokeBolls = new List<BrokeBoll>();
        
        int GetIndex()
        {
            for (int i = 0; i < brokeBolls.Count; i++)
                if (brokeBolls[i].gameObject.activeSelf == false) 
                    return i;
            brokeBolls.Add(Instantiate(ProjectSettings.ProjectSettings.Mine.BrokenBoll).GetComponent<BrokeBoll>());
            return brokeBolls.Count - 1;
        }
        brokeBolls[GetIndex()].Break(material, Pos);
    }

    private List<Renderer> Renderers
    {
        get
        {
            if (_Renderers == null)
            {

                List<Transform> dd = transform.Childs();
                _Renderers = new List<Renderer>();
                foreach (Transform t in dd) _Renderers.Add(t.GetComponent<Renderer>());
            }
            return _Renderers;
        }
    }
    private List<Renderer> _Renderers;
    private List<Rigidbody> Childs 
    {
        get 
        {
            if (_Childs == null) 
            {

                List<Transform> dd = transform.Childs();
                _Childs = new List<Rigidbody>();
                foreach (Transform t in dd) _Childs.Add(t.GetComponent<Rigidbody>());
            }
            return _Childs; 
        }
    }
    private List<Rigidbody> _Childs;
    private void OnEnable()
    {
        for (int i = 0; i < Childs.Count; i++)
        {
            Childs[i].velocity = Vector3.zero;
            Childs[i].transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
        AudioPlayer.PlayAudio("Crash");
    }

    private void Break(Material material, Vector3 Pos) 
    {
        for (int i = 0; i < Renderers.Count; i++) Renderers[i].material.color = material.GetColor("_GradientColorTwo");
        gameObject.SetActive(true);
        gameObject.transform.position = Pos;
    }

    float Ontime = 0;
    private void Update()
    {
        Ontime += Time.deltaTime;
        if (Ontime > 3f) 
        {
            Ontime = 0f;
            gameObject.SetActive(false);
        }
    }

}
