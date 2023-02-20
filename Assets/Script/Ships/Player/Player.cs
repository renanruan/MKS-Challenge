using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ShipHealth playerHealth;
    static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public static GameObject GetPlayer()
    {
        return instance.gameObject;
    }

    public static bool IsPlayerAlive()
    {
        return instance.playerHealth.IsAlive();
    }
}
