using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour
{
    [SerializeField] Text Pointsdisplay;

    private void Start()
    {
        LevelManeger.instance.SubscribeOnLevelStateChange(OnLevelStateChange);
        LevelPointsManeger.instance.SubscribeOnPointsAddedEvent(OnPointsAdded);
    }

    private void OnPointsAdded(int totalpoints)
    {
        Pointsdisplay.text = LevelPointsManeger.instance.GetTotalPoints().ToString();
    }

    void OnLevelStateChange(LEVE_STATE levelState)
    {
        if (levelState == LEVE_STATE.PLAYING)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
