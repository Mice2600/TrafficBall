using System.Collections;
using System.Collections.Generic;
using SystemBox;
using SystemBox.UI;
using UnityEngine;

public class GameOverSystem : MonoBehaviour
{
    public PlaceController spinPath => _spinPath ??= GameObject.FindObjectOfType<PlaceController>();
    private PlaceController _spinPath;
    public UIView GameOwerVewe;
    public UIView ADVewe;
    public TMPro.TextMeshProUGUI MaxScore;
    public TMPro.TextMeshProUGUI MyMaxScore;
    public bool ISGameOver;
    public void Play() 
    {
        ISGameOver = true;
        TimeControll.TimeStoppers.Add(this);
        GameOwerVewe.HideMoment();
        ADVewe.Show();
    }
    public void TryContinume() 
    {
        TList<PathBall> AllList = new List<PathBall>(spinPath.PathBalls);
        
        Ball ds = FindObjectOfType<MargeBall>().GetComponent<Ball>();
        BrokeBoll.Play(ds.SphereRenderer.material, ds.transform.position);
        Destroy(ds.gameObject);

        for (int i = 0; i < 4; i++)
        {
            Ball T = AllList.TakeOff(MinOneIndex());
            spinPath.PathBalls.Remove(T as PathBall);
            BrokeBoll.Play(T.SphereRenderer.material, T.transform.position);
            Destroy(T.gameObject);
        }
        CurrentContentSystem CurrentContentSystem = FindObjectOfType<CurrentContentSystem>();
        CurrentContentSystem.CreatNew(CurrentContentSystem.NextContentSystem.ContentObject.Content);
        CurrentContentSystem.NextContentSystem.CreatNew();
        ADVewe.Hide();
        TimeControll.TimeStoppers.Remove(this);
        int MinOneIndex() 
        {
            int MinIndex = 0;
            int Min = 99999;
            for (int i = 0; i < AllList.Count; i++)
            {
                if (AllList[i].Content < Min)
                {
                    Min = AllList[i].Content;
                    MinIndex = i;
                }
            }
            return MinIndex;
        }
    }
    public void OnThanksButton()
    {
        ADVewe.Hide();
        StartCoroutine(TT());
        IEnumerator TT()
        {

            Ball ds = FindObjectOfType<MargeBall>().GetComponent<Ball>();
            BrokeBoll.Play(ds.SphereRenderer.material, ds.transform.position);
            Destroy(ds.gameObject);

            TList<PathBall> AllList = new List<PathBall>(spinPath.PathBalls);
            Content BigOns = 0;
            while (spinPath.PathBalls.Count > 0)
            {
                Ball T = spinPath.PathBalls.RemoveRandomItem();
                if (T.Content > BigOns) BigOns = T.Content;
                BrokeBoll.Play(T.SphereRenderer.material, T.transform.position);
                Destroy(T.gameObject);
                yield return new WaitForSeconds(.1f);
            }
            spinPath.PathBalls = new LoopList<PathBall>();
            MaxScore.text = PlaceController.RecordScore + "";
            MyMaxScore.text = "Your Score : " + BigOns.Number;
            GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(GameAnalyticsSDK.GAProgressionStatus.Fail, $" Player got {BigOns.Number}");
            GameOwerVewe.Show();

            CurrentContentSystem CurrentContentSystem = FindObjectOfType<CurrentContentSystem>();
            CurrentContentSystem.CreatNew(CurrentContentSystem.NextContentSystem.NewContentAlgaritm());
            CurrentContentSystem.NextContentSystem.CreatNew();

        }
    }
    public void Restart() 
    {
        TimeControll.TimeStoppers.Remove(this);
        GameOwerVewe.Hide();
    }
    
}
