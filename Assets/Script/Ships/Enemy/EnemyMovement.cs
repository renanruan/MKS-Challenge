using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] Transform turnableParts;
    Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void MoveForward()
    {
        transform.position += turnableParts.right * movementSpeed * Time.deltaTime;
    }

    public void TurnToTarget()
    {
        float angleToTarget = Vector3.SignedAngle(turnableParts.right, target.position - transform.position,Vector3.forward);

        if(Mathf.Abs(angleToTarget) < 2)
        {
            return;
        }

        if(angleToTarget > 0)
        {
            turnableParts.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }
        else
        {
            turnableParts.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        }
    }

    public void SnapTurn()
    {
        turnableParts.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(target.position - transform.position, Vector3.right, Vector3.forward));
    }
}
