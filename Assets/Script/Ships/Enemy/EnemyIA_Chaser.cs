using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA_Chaser : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float minDistance;
    [SerializeField] float maxDistance;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] DetectWallAhead wallDetector;
    [SerializeField] Transform turnablePartss;

    Transform playerTransform;
    float currentSpeed;
    Vector3 direction;

    private void Start()
    {
        GetPlayer();
        enemyMovement.SetTarget(playerTransform);
    }

    void GetPlayer()
    {
        playerTransform = Player.GetPlayer().transform;
    }

    private void FixedUpdate()
    {
        enemyMovement.TurnToTarget();
        GetSpeedFromDistanceToPlayer();
        GetDirectionVector();
        TurnToDirection();
        Move();
    }

    void GetSpeedFromDistanceToPlayer()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, (1f - (distance - minDistance) / (maxDistance - minDistance)));
    }

    void GetDirectionVector()
    {
        direction = (playerTransform.position - transform.position).normalized;

        if (!wallDetector.HasClearPath())
        {
            Vector2 tangent = Vector3.Cross(wallDetector.GetCollisionNormal(), Vector3.forward);
            direction = tangent;
            wallDetector.SetDistanceToCheck(0.52f);
        }
        else
        {
            wallDetector.SetDistanceToCheck(0.48f);
        }
    }

    void TurnToDirection()
    {
        turnablePartss.rotation = Quaternion.Euler(0,0, Mathf.Rad2Deg * Mathf.Atan2(direction.y,direction.x));
    }

    void Move()
    {
        transform.position += currentSpeed * direction * Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, minDistance);
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
