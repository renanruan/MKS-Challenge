using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : ShipShooting
{
    [SerializeField] Transform shootPoint;

    public override void PullTrigger()
    {
        CannonBall cannonBall = Instantiate(cannonBallObject, shootPoint.position, Quaternion.identity).GetComponent<CannonBall>();
        cannonBall.SetDirection(shootPoint.position - transform.position);
        cannonBall.SetTarget(DETECTABLE_LAYERS.Player);
        cannonSound.Play();
    }
}