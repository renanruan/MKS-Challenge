using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DETECTABLE_LAYERS { Player, Enemy, Wall };

public class DetectWallAhead : MonoBehaviour
{
    [SerializeField] float distanceToCheck;
    [SerializeField] float radius;
    [SerializeField] DETECTABLE_LAYERS[] LayersToDetect;

    bool clearPath;

    // Update is called once per frame
    void Update()
    {
        clearPath = CheckPathAhed();
    }

    bool CheckPathAhed()
    {
        bool detected = false;
        foreach(DETECTABLE_LAYERS layer in LayersToDetect)
        {
            detected |= Physics2D.CircleCast(transform.position, radius, transform.right, distanceToCheck, LayerMask.GetMask(layer.ToString())).transform != null;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distanceToCheck);
        Gizmos.DrawWireSphere(transform.position + transform.right * distanceToCheck, radius);
    }
}
