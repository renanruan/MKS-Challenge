using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LEVE_STATE { COUNTING_TO_START, PLAYING, FINISHED_LEVEL }
public delegate void LevelStateChange(LEVE_STATE levelState);

public class LevelManeger : MonoBehaviour
{
    public static LevelManeger instance;

    [SerializeField] LEVE_STATE levelState;
    event LevelStateChange onStateChange;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CallLevelStateChange();
    }

    public void SubscribeOnLevelStateChange(LevelStateChange onStateChange)
    {
        this.onStateChange += onStateChange;
    }

    public  void StartPlaying()
    {
        levelState = LEVE_STATE.PLAYING;
        CallLevelStateChange();
    }

    public void FinishPlaying()
    {
        levelState = LEVE_STATE.FINISHED_LEVEL;
        CallLevelStateChange();
    }

    public void RestartLevel()
    {
        levelState = LEVE_STATE.COUNTING_TO_START;
        CallLevelStateChange();
    }

    void CallLevelStateChange()
    {
        onStateChange.Invoke(levelState);
    }

}
