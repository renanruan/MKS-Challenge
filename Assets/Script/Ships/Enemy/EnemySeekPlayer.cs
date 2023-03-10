using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SeeingPlayer(bool isSeeing);

public class EnemySeekPlayer : MonoBehaviour
{
    [SerializeField] float signRange;
    Transform playerTransform;
    event SeeingPlayer seeingPlayerEvent;
    bool wasSeeing = false;

    private void Start()
    {
        playerTransform = Player.GetPlayer().transform;
    }

    public void SubscribeOnSeeingPlayerEvent(SeeingPlayer seeingPlayerEvent)
    {
        this.seeingPlayerEvent += seeingPlayerEvent;
    }

    private void Update()
    {
        bool isSeeingPlayerNow = IsPlayerInRange();

        if(isSeeingPlayerNow != wasSeeing)
        {
            wasSeeing = isSeeingPlayerNow;
            seeingPlayerEvent?.Invoke(wasSeeing);
        }
        
    }

    bool IsPlayerInRange()
    {
        if (wasSeeing)
        {
            return Vector2.Distance(transform.position, playerTransform.position) < signRange * 1.5f;
        }
        else
        {
            return Vector2.Distance(transform.position, playerTransform.position) < signRange;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, signRange);
    }

}
