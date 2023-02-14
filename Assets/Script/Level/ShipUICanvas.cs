using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUICanvas : MonoBehaviour
{
    static ShipUICanvas instance;

    private void Awake()
    {
        instance = this;
    }

    public static Transform GetCavas()
    {
        return instance.transform;
    }
}
