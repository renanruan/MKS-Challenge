using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    static GameManeger instance;

    float levelDuration = 100;
    float enemySpawnTime = 5;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static float GetLevelDuration()
    {
        return instance.levelDuration;
    }

    public static float GetEnemySpawnTime()
    {
        return instance.enemySpawnTime;
    }
}
