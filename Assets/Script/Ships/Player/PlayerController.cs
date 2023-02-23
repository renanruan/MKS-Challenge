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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotForward();
        }
    }

    public void ShotForward()
    {
        if (playerForwardShooting.CanShot())
        {
            playerAnimationControl.StartForwardShootAnimation();
            playerForwardShooting.Reload();
        }
    }

    void GetLateralShootButton()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShotLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ShotRight();
        }
    }

    public void ShotLeft()
    {
        if (playerTripleShootingLeft.CanShot() && !playerAnimationControl.IsShipBodyAnimating())
        {
            playerAnimationControl.StartLeftShootAnimation();
            playerTripleShootingLeft.Reload();
        }
    }

    public void ShotRight()
    {
        if (playerTripleShootingRight.CanShot() && !playerAnimationControl.IsShipBodyAnimating())
        {
            playerAnimationControl.StartRightShootAnimation();
            playerTripleShootingRight.Reload();
        }
    }
}
