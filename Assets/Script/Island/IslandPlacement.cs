using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandPlacement : MonoBehaviour
{
    [SerializeField] Collider2D myCollider;

    Rect placeableArea;

    public void PlaceIsland(Rect rect)
    {
        placeableArea = rect;

        ChooseRandomAngle();
        ChooseRandomPosition();
    }

    void ChooseRandomAngle()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * (int)(Random.Range(0, 4)));
    }

    void ChooseRandomPosition()
    {
        transform.position = new Vector3(Random.Range(placeableArea.xMin,placeableArea.xMax), Random.Range(placeableArea.yMin, placeableArea.yMax));
    }

    bool IsFreeOfCollision()
    {
        bool one = myCollider.IsTouchingLayers(LayerMask.GetMask(DETECTABLE_LAYERS.Wall.ToString()));
        bool two = myCollider.IsTouchingLayers(LayerMask.GetMask(DETECTABLE_LAYERS.Player.ToString()));
        bool tree = myCollider.IsTouchingLayers(LayerMask.GetMask(DETECTABLE_LAYERS.Enemy.ToString()));
        return !one && !two  && !tree;
    }

    private void Update()
    {
        if(LevelManeger.instance.GetLevelState() != LEVE_STATE.LOADING)
        {
            enabled = false;
        }

        if (!IsFreeOfCollision())
        {
            ChooseRandomAngle();
            ChooseRandomPosition();
        }
    }
}
