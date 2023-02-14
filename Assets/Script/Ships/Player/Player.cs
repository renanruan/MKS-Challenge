using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static Player instance;

    private void Awake()
    {
        instance = this;
    }

    public static GameObject GetPlayer()
    {
        return instance.gameObject;
    }
}
