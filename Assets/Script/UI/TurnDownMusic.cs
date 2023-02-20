using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDownMusic : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        LevelManeger.instance.SubscribeOnLevelStateChange(CheckEndOfLevel);
    }

    private void CheckEndOfLevel(LEVE_STATE levelState)
    {
        if(levelState == LEVE_STATE.FINISHED_LEVEL)
        {
            animator.SetTrigger("EndLevel");
        }
    }
}
