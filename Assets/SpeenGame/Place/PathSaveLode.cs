using Servises;
using System.Collections.Generic;
using UnityEngine;

public class PathSaveLode : MonoBehaviour
{
    private PlaceController PlaceController => _PlaceController ??= FindObjectOfType<PlaceController>();
    private PlaceController _PlaceController;

    void Start()
    {
        Lode();
    }

    float perTime;
    void Update()
    {
        perTime += Time.deltaTime;
        if (perTime > 2) 
        {
            perTime = 0;
            Save();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    

    public void Save() 
    {
        List<pathBallData> ListData = new List<pathBallData>();
        PlaceController.PathBalls.ForEach(a => ListData.Add(new pathBallData { Pos = a.transform.position, ContentAlgaritmNumber = a.Content.AlgaritmNumber }));
        
        PlayerPrefs.SetString("PathName" + transform.name, JsonHelper.ToJson(ListData.ToArray()));
    }
    public void Lode()
    {
        string DD = PlayerPrefs.GetString("PathName" + transform.name);
        if (string.IsNullOrEmpty(DD)) 
        {
            //default
            DD = JsonHelper.ToJson(new pathBallData[]{ 
                new pathBallData { ContentAlgaritmNumber = 3, Pos =new Vector3(-1.96f, 0.7f, -1.62f) },
                new pathBallData { ContentAlgaritmNumber = 2,Pos = new Vector3(-1.14f,0.7f, -2.28f) }, new pathBallData { ContentAlgaritmNumber = 1,Pos = new Vector3(-0.06f,0.7f,-2.51f) } });
        }
        pathBallData[] pathBallDatas = JsonHelper.FromJson<pathBallData>(DD);
        if (pathBallDatas == null) return;
        for (int i = 0; i < pathBallDatas.Length; i++)
        {
            Content NEwcontent = new Content { AlgaritmNumber = pathBallDatas[i].ContentAlgaritmNumber };
            GameObject InN = Instantiate(ProjectSettings.ProjectSettings.Mine.BallPrefab);
            Ball ball = InN.GetComponent<Ball>();
            ball.SphereRenderer.material = new Material(ProjectSettings.ProjectSettings.Mine.GetAlgaritmBallMaterial(NEwcontent));
            ball.Content = NEwcontent;
            InN.transform.position = pathBallDatas[i].Pos;
            PlaceController.TryMargeNewContent(InN);
            
        }
    }
}
[System.Serializable]
public struct pathBallData 
{
    public Vector3 Pos;
    public int ContentAlgaritmNumber;
}