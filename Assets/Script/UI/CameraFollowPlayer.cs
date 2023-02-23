using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Rect cameraArea;
    Transform player;
    Vector3 playerLastPosition;
    bool moveOnX = true;
    bool moveOnY = true;
    bool followRotation = false;

    void Start()
    {
        player = Player.GetPlayer().transform.GetChild(0);
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

        if (transform.rotation.z != player.rotation.z)
        {
            CheckDifference();
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

    void CheckDifference()
    {
        float diferrence = (player.rotation.eulerAngles.z + 360) % 360 - (transform.rotation.eulerAngles.z + 360) % 360;
        float rotationDirection = Mathf.Sign(diferrence);
        diferrence = Mathf.Abs(diferrence);

        if(diferrence > 180)
        {
            diferrence = 360 - diferrence;
            rotationDirection *= -1;
        }

        if(!followRotation && (diferrence > 60))
        {
            followRotation = true;
        }
        else if (followRotation)
        {
            transform.Rotate(new Vector3(0, 0, rotationDirection * rotationSpeed * Time.deltaTime));

            if (diferrence < 30)
            {
                followRotation = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(cameraArea.center, cameraArea.size);
    }

}
