using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : ShipAnimationControl
{
    [SerializeField] PlayerForwardShooting playerForwardShooting;
    [SerializeField] PlayerTripleShooting playerLTripleShooting;
    [SerializeField] PlayerTripleShooting playerRTripleShooting;

    bool shipBodyAnimating = false;

    public void StartForwardShootAnimation()
    {
        animator.SetTrigger("SingleShot");
    }

    public void StartLeftShootAnimation()
    {
        animator.SetTrigger("LTripleShot");
        shipBodyAnimating = true;
    }

    public void StartRightShootAnimation()
    {
        animator.SetTrigger("RTripleShot");
        shipBodyAnimating = true;
    }

    public void ExecuteForwardShoot()
    {
        playerForwardShooting.PullTrigger();
    }

    public void ExecuteTripleLeftShoot()
    {
        playerLTripleShooting.PullTrigger();
    }

    public void ExecuteTripleRightShoot()
    {
        playerRTripleShooting.PullTrigger();
    }

    public void EndShipBodyAnimation()
    {
        shipBodyAnimating = false;
    }

    public bool IsShipBodyAnimating()
    {
        return shipBodyAnimating;
    }
}
