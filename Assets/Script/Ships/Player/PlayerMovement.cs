using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] Transform turnableParts;
    [SerializeField] DetectWallAhead wallDetector;

    float turnInput = 0;
    float forwardInput = 0;

    private void FixedUpdate()
    {
        CheckTurn();
        CheckForward();
    }

    void CheckTurn()
    {
        if(turnInput != 0)
        {
            MakeTurn();
        }
    }

    void MakeTurn()
    {
        turnableParts.transform.Rotate(Vector3.forward, -turnInput * turnSpeed * Time.deltaTime);
    }

    void CheckForward()
    {
        if(forwardInput >= 0 && wallDetector.HasClearPath())
        {
            GoForward();
        }
    }

    void GoForward()
    {
        float currentAngle = turnableParts.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        transform.position += new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle)) * forwardSpeed * forwardInput * Time.deltaTime;
    }

    public void SetTurnInput(float turnInput)
    {
        this.turnInput = turnInput;
    }

    public void SetForwardInput(float forwardInput)
    {
        this.forwardInput = forwardInput;
    }


}
