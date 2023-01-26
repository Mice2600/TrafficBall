using System.Collections;
using System.Collections.Generic;
using SystemBox;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
   public void Plsy(string ID) => AudioPlayer.PlayAudio(ID);//
}
