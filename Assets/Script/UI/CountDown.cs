using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public void StartGame()
    {
        LevelManeger.instance.StartPlaying();
    }
}
