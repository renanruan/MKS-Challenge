using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimeManeger : MonoBehaviour
{
    [SerializeField] Text TimerDisplay;
    float maxTimer;
    float currentTimer;

    bool counting;

    private void Start()
    {
        LevelManeger.instance.SubscribeOnLevelStateChange(OnLevelStateChange);
        SetTimerDuration(GameManeger.GetLevelDuration());
    }

    void SetTimerDuration(float time)
    {
        maxTimer = time;
    }

    void OnLevelStateChange(LEVE_STATE levelState)
    {
        if (levelState == LEVE_STATE.PLAYING)
        {
            currentTimer = maxTimer;
            UpdateTimerDisplay();
            TimerDisplay.enabled = true;
            counting = true;
        }
        else
        {
            counting = false;
            TimerDisplay.enabled = false;
        }
    }

    private void Update()
    {
        if (counting)
        {
            CountDown();
            UpdateTimerDisplay();
        }
    }

    void CountDown()
    {
        currentTimer = Mathf.Max(0, currentTimer - Time.deltaTime);

        if(currentTimer == 0)
        {
            FinishedCounting();
        }
    }

    void FinishedCounting()
    {
        LevelManeger.instance.FinishPlaying();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTimer / 60f);
        int seconds = Mathf.FloorToInt(currentTimer - 60f * minutes);
        TimerDisplay.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }
}
