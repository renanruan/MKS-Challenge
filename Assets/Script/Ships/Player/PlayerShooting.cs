using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject cannonBallObject;
    [SerializeField] Transform frontalShootingPoint;
    [SerializeField] Transform[] leftShootingPoints;
    [SerializeField] Transform[] reftShootingPoints;

    public void ShootForward()
    {
        CannonBall cannonBall = Instantiate(cannonBallObject, frontalShootingPoint.position, Quaternion.identity).GetComponent<CannonBall>();
        cannonBall.SetDirection(frontalShootingPoint.position - transform.position);
        cannonBall.SetTarget(DETECTABLE_LAYERS.Enemy);
    }
}
