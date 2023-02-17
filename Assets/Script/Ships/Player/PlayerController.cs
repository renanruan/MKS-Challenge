using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerForwardShooting playerForwardShooting;
    [SerializeField] PlayerTripleShooting playerTripleShootingLeft;
    [SerializeField] PlayerTripleShooting playerTripleShootingRight;
    [SerializeField] PlayerAnimationControl playerAnimationControl;
    [SerializeField] PlayerTurnSail playerTurnSail;

    void Update()
    {
        GetTurnButton();
        GetForwardButton();
        GetFrontalShootButton();
        GetLateralShootButton();
    }

    void GetTurnButton()
    {
        float turnInput = Input.GetAxis("Horizontal");
        playerMovement.SetTurnInput(turnInput);
        playerTurnSail.SetTurnInput(turnInput);
    }

    void GetForwardButton()
    {
        playerMovement.SetForwardInput(Input.GetAxis("Vertical"));
    }

    void GetFrontalShootButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerForwardShooting.CanShot())
        {
            playerAnimationControl.StartForwardShootAnimation();
            playerForwardShooting.Reload();
        }
    }

    void GetLateralShootButton()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerTripleShootingLeft.CanShot() && !playerAnimationControl.IsShipBodyAnimating())
        {
            playerAnimationControl.StartLeftShootAnimation();
            playerTripleShootingLeft.Reload();
        }

        if (Input.GetKeyDown(KeyCode.E) && playerTripleShootingRight.CanShot() && !playerAnimationControl.IsShipBodyAnimating())
        {
            playerAnimationControl.StartRightShootAnimation();
            playerTripleShootingRight.Reload();
        }
    }
}
