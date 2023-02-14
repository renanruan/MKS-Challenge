using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rect cameraArea;
    Transform player;
    Vector3 playerLastPosition;
    bool moveOnX = true;
    bool moveOnY = true;

    void Start()
    {
        player = Player.GetPlayer().transform;
        playerLastPosition = player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.position != playerLastPosition)
        {
            CheckBlockedAxis();
            transform.position = CalculateNewPosition();
            playerLastPosition = player.position;
        }
    }

    void CheckBlockedAxis()
    {
        if(Mathf.Abs(player.position.x - transform.position.x) < 0.2f)
        {
            moveOnX = true;
        }
        else
        if (Mathf.Abs(player.position.x - transform.position.x) > 1f)
        {
            moveOnX = false;
        }

        if (Mathf.Abs(player.position.y - transform.position.y) < 0.2f)
        {
            moveOnY = true;
        }
        else
        if (Mathf.Abs(player.position.y - transform.position.y) > 1f)
        {
            moveOnY = false;
        }
    }

    Vector3 CalculateNewPosition()
    {
        Vector3 deltaPosition = player.position - playerLastPosition;

        float xPosition = (moveOnX) ? Mathf.Clamp(transform.position.x + deltaPosition.x, cameraArea.xMin, cameraArea.xMax) : transform.position.x;
        float yPosition = (moveOnY) ? Mathf.Clamp(transform.position.y + deltaPosition.y, cameraArea.yMin, cameraArea.yMax) : transform.position.y;
        
        return new Vector3( xPosition, yPosition, transform.position.z );
    }

}
