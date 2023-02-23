using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetrits : MonoBehaviour
{
    [SerializeField] GameObject[] Detrits;
    [SerializeField] [Range(0,100)] int Odds;

    static LevelDetrits instance;

    private void Awake()
    {
        instance = this;
    }

    public static void DamageAtPoint(Vector2 position)
    {
        if (instance.TakeOdds())
        {
            instance.InstantiateDetrits(position);
        }
    }

    bool TakeOdds()
    {
        return Odds > Random.Range(0, 100);
    }

    void InstantiateDetrits(Vector2 position)
    {
        Instantiate(Detrits[Random.Range(0, Detrits.Length)], position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }
}
