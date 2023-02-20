using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] float acceleration = 5;
    [SerializeField] float speed = 0;
    [SerializeField] float maxSpeed = 15;
    [SerializeField] float scaleMovement;

    private void Update()
    {
        ChangeSpeed();
        Move();
    }

    void ChangeSpeed()
    {
        speed += acceleration * Time.deltaTime;

        if(Mathf.Abs(speed) > maxSpeed)
        {
            acceleration *= -1;
        }
    }

    void Move()
    {
        transform.position += new Vector3(scaleMovement *speed * Time.deltaTime, 0, 0);
    }
}
