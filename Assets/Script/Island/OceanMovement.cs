using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 gridCell;

    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position += gridCell * speed * Time.deltaTime;

        if(transform.position.x > initialPosition.x + gridCell.x)
        {
            transform.position -= gridCell;
        }
    }
}
