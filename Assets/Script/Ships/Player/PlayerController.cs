using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShooting playerShooting;

    void Update()
    {
        GetTurnButton();
        GetForwardButton();
        GetFrontalShootButton();
        GetLateralShootButton();
    }

    void GetTurnButton()
    {
        playerMovement.SetTurnInput(Input.GetAxis("Horizontal"));
    }

    void GetForwardButton()
    {
        playerMovement.SetForwardInput(Input.GetAxis("Vertical"));
    }

    void GetFrontalShootButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerShooting.ShootForward();
        }
    }

    void GetLateralShootButton()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(32, 32));
    }
}
