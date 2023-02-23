using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    static GameManeger instance;

    int levelDuration = 100;
    int enemySpawnTime = 5;
    bool firstPlay = true;


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

    public static int GetLevelDuration()
    {
        return instance.levelDuration;
    }

    public static void SetLevelDuration(int levelDuration)
    {
        instance.levelDuration = levelDuration;
    }

    public static int GetEnemySpawnTime()
    {
        return instance.enemySpawnTime;
    }

    public static void SetEnemySpawnTime(int enemySpawnTime)
    {
        instance.enemySpawnTime = enemySpawnTime;
    }

    public static bool IsFirstPlay()
    {
        return instance.firstPlay;
    }

    public static void PlayFirstPlay()
    {
        instance.firstPlay = false;
    }
}
