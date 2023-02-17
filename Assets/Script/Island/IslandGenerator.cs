using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    [SerializeField] Rect spawnArea;
    [SerializeField] GameObject[] IslandPrefabs;

    int numOfIslands;
    [SerializeField] int minNumOfIslands;
    [SerializeField] int maxNumOfIslands;

    List<GameObject> SpawnedIslands = new List<GameObject>();

    private void Start()
    {
        SpawnProcess();    
    }

    void SpawnProcess()
    {
        ClearExistingIslands();
        ChooseRandoNumberOfIslands();
        SpawnNewIslands();
    }

    void ClearExistingIslands()
    {
        int existingIslands = SpawnedIslands.Count;

        for(int i = 0; i < existingIslands; i++)
        {
            Destroy(SpawnedIslands[0]);
        }

        SpawnedIslands.Clear();
    }

    void ChooseRandoNumberOfIslands()
    {
        numOfIslands = Random.Range(minNumOfIslands, maxNumOfIslands + 1);
    }

    void SpawnNewIslands()
    {
        for (int i = 0; i < numOfIslands; i++)
        {
            GameObject newIsland = GameObject.Instantiate(ChooseRandomIsland(), transform);

            SpawnedIslands.Add(newIsland);

            newIsland.GetComponent<IslandPlacement>().PlaceIsland(spawnArea);
        }
    }

    GameObject ChooseRandomIsland()
    {
        return IslandPrefabs[Random.Range(0, IslandPrefabs.Length)];
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(spawnArea.center, spawnArea.size);
    }
}
