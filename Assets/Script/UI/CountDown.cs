using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] Animator animator;


    private void Start()
    {
        LevelManeger.instance.SubscribeOnLevelStateChange(CheckIfCounting);
    }

    private void CheckIfCounting(LEVE_STATE levelState)
    {
        if(levelState == LEVE_STATE.COUNTING_TO_START)
        {
            animator.enabled = true;
        }
    }

    public void StartGame()
    {
        LevelManeger.instance.StartPlaying();
    }
}
