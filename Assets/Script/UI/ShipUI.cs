using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUI : MonoBehaviour
{
    [SerializeField] Transform fillMask;
    [SerializeField] Animator animator;
    Transform shipToFollow;

    private void Update()
    {
        transform.position = shipToFollow.position;
    }

    public void SetShipToFollow(Transform shipToFollow)
    {
        this.shipToFollow = shipToFollow;
    }

    public void SetHealthPercentage(float healthPercentage)
    {
        fillMask.localScale = new Vector3(healthPercentage, 1, 1);

        if(healthPercentage > 0)
        {
            animator.SetTrigger("ShowUI");
        }
        else
        {
            animator.SetTrigger("HideUI");
        }

    }
}
