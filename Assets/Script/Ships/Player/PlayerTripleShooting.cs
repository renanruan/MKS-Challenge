using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTripleShooting : ShipShooting
{
    [SerializeField] Transform[] tripleShootingPoints;

    Transform currentOrigin;
    Vector3 currentDirection;

    public override void PullTrigger()
    {
        currentDirection = tripleShootingPoints[1].position - transform.position;

        foreach(Transform t in tripleShootingPoints)
        {
            currentOrigin = t;
            PullCurrentTrigger();
        }

        cannonSound.Play();

    }

    void PullCurrentTrigger()
    {
        CannonBall cannonBall = Instantiate(cannonBallObject, currentOrigin.position, Quaternion.identity).GetComponent<CannonBall>();
        cannonBall.SetDirection(currentDirection);
        cannonBall.SetTarget(DETECTABLE_LAYERS.Enemy);
        
    }
}
