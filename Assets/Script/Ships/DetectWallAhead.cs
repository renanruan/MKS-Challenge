using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DETECTABLE_LAYERS { Player, Enemy, Wall };

public class DetectWallAhead : MonoBehaviour
{
    [SerializeField] float distanceToCheck;
    [SerializeField] float radius;
    [SerializeField] Transform shipFace;
    [SerializeField] DETECTABLE_LAYERS[] LayersToDetect;

    bool clearPath;
    Vector2 normal;

    // Update is called once per frame
    void Update()
    {
        clearPath = CheckPathAhaed();
    }

    bool CheckPathAhaed()
    {
        bool detected = false;
        foreach(DETECTABLE_LAYERS layer in LayersToDetect)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, shipFace.right, distanceToCheck, LayerMask.GetMask(layer.ToString()));

            if(hit.transform != null)
            {
                detected = true;
                normal = hit.normal;
            }
        }
        return !detected;
    }

    public bool HasClearPath()
    {
        return clearPath;
    }

    public Vector2 GetAheadVector()
    {
        return transform.right;
    }

    public Vector2 GetCollisionNormal()
    {
        return normal;
    }

    public void SetDistanceToCheck(float distanceToCheck)
    {
        this.distanceToCheck = distanceToCheck;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distanceToCheck);
        Gizmos.DrawWireSphere(transform.position + transform.right * distanceToCheck, radius);
    }
}
