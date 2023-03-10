using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA_Shooter : MonoBehaviour
{
    enum EnemyMode { RandomSail, ShootPlayer};

    [SerializeField] EnemySeekPlayer seekPlayer;
    [SerializeField] EnemyMovement movement;
    [SerializeField] EnemyShooting shooting;
    [SerializeField] DetectWallAhead wallDetector;

    Transform playerTransform;
    EnemyMode enemyMode;
    GameObject fakeTarget;

    private void Start()
    {
        enemyMode = EnemyMode.RandomSail;
        GetPlayer();
        CreateFakeTarget();
        RegisterOnPlayerSeeker();
        ChooseRandomDirection();
    }

    void GetPlayer()
    {
        playerTransform = Player.GetPlayer().transform;
    }

    void CreateFakeTarget()
    {
        fakeTarget = Instantiate(new GameObject(), transform);
        movement.SetTarget(fakeTarget.transform);
    }

    void RegisterOnPlayerSeeker()
    {
        seekPlayer.SubscribeOnSeeingPlayerEvent(SpotPlayer);
    }

    void SpotPlayer(bool HasSpoted)
    {
        if (HasSpoted)
        {
            enemyMode = EnemyMode.ShootPlayer;
            movement.SetTarget(playerTransform);
        }
        else
        {
            enemyMode = EnemyMode.RandomSail;
            movement.SetTarget(fakeTarget.transform);
            ChooseRandomDirection();
        }
    }

    private void FixedUpdate()
    {
        movement.TurnToTarget();

        switch (enemyMode)
        {
            case EnemyMode.RandomSail:
                if(wallDetector.HasClearPath())
                {
                    movement.MoveForward();
                }
                else
                {
                    ChooseRandomDirection();
                    movement.SnapTurn();
                }
                break;
            case EnemyMode.ShootPlayer:
                if(shooting.CanShot() && IsPlayerOnAim())
                {
                    shooting.PullTrigger();
                    shooting.Reload();
                }
                break;
        }
    }

    void ChooseRandomDirection()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        fakeTarget.transform.localPosition = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));
    }

    bool IsPlayerOnAim()
    {
        return Vector2.Angle(playerTransform.position - transform.position, wallDetector.GetAheadVector()) < 15;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, Quaternion.Euler(0, 0, 15) * wallDetector.GetAheadVector() * 3 + transform.position);
        Gizmos.DrawLine(transform.position, Quaternion.Euler(0, 0, -15) * wallDetector.GetAheadVector() * 3 + transform.position);
    }
}
