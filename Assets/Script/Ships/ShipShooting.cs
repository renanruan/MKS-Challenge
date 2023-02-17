using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipShooting : MonoBehaviour
{
    [SerializeField] float cooldown;
    [SerializeField] protected GameObject cannonBallObject;

    bool recharging;
    float delay;

    private void Update()
    {
        Cooldown();
    }

    void Cooldown()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            recharging = false;
        }
    }


    public bool CanShot()
    {
        return !recharging;
    }

    public void Reload()
    {
        recharging = true;
        delay = cooldown;
    }

    public abstract void PullTrigger();


}
