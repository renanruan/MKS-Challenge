using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] float cooldown;
    [SerializeField] GameObject cannonBallObject;
    [SerializeField] Transform shootPoint;

    bool recharging;
    float delay;

    private void Update()
    {
        Cooldown();    
    }

    void Cooldown()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            recharging = false;
        }
    }


    public void Shoot()
    {
        if (!recharging)
        {
            PullTrigger();
            Reload();
        }
    }

    void PullTrigger()
    {
        CannonBall cannonBall = Instantiate(cannonBallObject, shootPoint.position, Quaternion.identity).GetComponent<CannonBall>();
        cannonBall.SetDirection(shootPoint.position - transform.position);
        cannonBall.SetTarget(DETECTABLE_LAYERS.Player);
    }

    void Reload()
    {
        recharging = true;
        delay = cooldown;
    }
}
