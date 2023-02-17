using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDeath : MonoBehaviour
{
    [SerializeField] LockScripts lockScripts;
    [SerializeField] Collider2D myCollider;

    public void Die()
    {
        StopCompletly();
        DeactiveCollider();
    }

    void StopCompletly()
    {
        lockScripts.LockAndUnlockAll(false);
    }

    void DeactiveCollider()
    {
        myCollider.enabled = false;
    }
}
