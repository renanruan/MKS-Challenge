using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Rect spawnArea;
    [SerializeField] GameObject[] EnemyPrefabs;
    [SerializeField] float minDistanceToPlayer;

    Vector3 currentPoint;

    float maxTimer;
    float currentTimer;


    private void Start()
    {
        maxTimer = GameManeger.GetEnemySpawnTime();
        LevelManeger.instance.SubscribeOnLevelStateChange(OnLevelStateChange);
    }

    private void OnLevelStateChange(LEVE_STATE levelState)
    {
        if(levelState == LEVE_STATE.PLAYING)
        {
            currentTimer = maxTimer;
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer < 0)
        {
            currentTimer = maxTimer;
            SpawnProcess();
        }
    }

    void SpawnProcess()
    {
        FindEmptySpace();
        SpawnEnemy();
    }

    void FindEmptySpace()
    {
        do
        {
            currentPoint = new Vector3(Random.Range(spawnArea.xMin, spawnArea.xMax), Random.Range(spawnArea.yMin, spawnArea.yMax)) + Player.GetPlayer().transform.position;
        } while (IsCloseToPlayer() || IsSpaceOccupied());
    }

    bool IsCloseToPlayer()
    {
        return Vector2.Distance(currentPoint, Player.GetPlayer().transform.position) < minDistanceToPlayer;
    }

    bool IsSpaceOccupied()
    {
        return Physics2D.BoxCast(currentPoint, new Vector2(1.5f, 0.6f), 0, Vector2.zero, 0, LayerMask.GetMask(DETECTABLE_LAYERS.Wall.ToString())).collider != null;
    }

    void SpawnEnemy()
    {
        Instantiate(ChooseRandomEnemy(), currentPoint, transform.rotation, GameObject.Find("Ships").transform);
    }

    GameObject ChooseRandomEnemy()
    {
        return EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(spawnArea.center, spawnArea.size);
    }
}
