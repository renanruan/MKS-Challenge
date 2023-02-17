using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardShooting : ShipShooting
{
    [SerializeField] Transform frontalShootingPoint;

    public override void PullTrigger()
    {
        CannonBall cannonBall = Instantiate(cannonBallObject, frontalShootingPoint.position, Quaternion.identity).GetComponent<CannonBall>();
        cannonBall.SetDirection(frontalShootingPoint.position - transform.position);
        cannonBall.SetTarget(DETECTABLE_LAYERS.Enemy);
    }


}
