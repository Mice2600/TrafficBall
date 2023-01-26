using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using SystemBox;
using UnityEngine;

[System.Serializable]
public struct Content
{
    static Content() 
    {
        LoopList<string> listColors = new LoopList<string>(){"<#16FF00>","<#00FFD4>","<#00C8FF>","<#9C4AFF>","<#BFFF4A>","<#4AFFAE>","<#9392FF>","<#E992FF>","<#FF92B5>","<#FFB592>","<#FFE600>"};
        List<string> list = new List<string>()
        {
            "M", "B","T","Q","Sx","St","Oc","N","D","U","DU","TD","QT","QD","SD","SPD","OD","ND",
            "V","UT","DG","TG","QTG","QG","SG","SPG","OG","NG","TRG","UG","Ten","CT","Gol",
            "∞","Q∞","W∞","E∞","R∞","T∞","Y∞","U∞","I∞","O∞","P∞","A∞","S∞","D∞","F∞","T∞",
            "K","M","T","Q","Sx","St","Oc","N","D","U","DU","TD","QT","QD","SD","SPD","OD",
            "ND","V","UT","DG","TG","QTG","QG","SG","SPG","OG","NG","TRG","UG","Ten","CT","Gol",
        };
        List<string> D = new List<string>() {"1", "2", "4", "8", "16", "32", "64", "128", "256", "512" };
        NumberText = new List<string>(){"1","2","4","8","16","32","64","128","256","512","1024","2048","4<#FFE600><size=4>K", 
            "8<#FFE600><size=4>K","16<#FFE600><size=3>K" ,"32<#FFE600><size=3>K","64<#FFE600><size=3>K", "128<#FFE600><size=2>K","256<#FFE600><size=2>K" ,"512<#FFE600><size=2>K"};
        for (int i = 0; i < list.Count; i++)
            for (int S = 0; S < D.Count; S++) 
            {
                float SizeF = (D[S].ToString().Length >= 3)? 2f : (D[S].ToString().Length == 2) ? 3f : 4f;
                string Size = $"<size={SizeF}>";
                NumberText.Add(D[S]+ listColors[i] + Size + list[i]);

            }
    }

    public readonly static List<string> NumberText;
    public string Number => NumberText[AlgaritmNumber];
    public int AlgaritmNumber;
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (obj is not Content) return false;
        if ((obj as Content?).Value.AlgaritmNumber != AlgaritmNumber) return false;
        return true;
    }
    public override int GetHashCode() => base.GetHashCode();
    public static bool operator !=(Content a, Content d) => !a.Equals(d);
    public static bool operator ==(Content a, Content d) => a.Equals(d);
    public static  implicit operator int(Content a) => a.AlgaritmNumber;
    public static  implicit operator Content(int a) => new Content {AlgaritmNumber = a };
}
