using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipDeath : MonoBehaviour
{
    [SerializeField] LockScripts lockScripts;
    [SerializeField] Collider2D myCollider;
    [SerializeField] DeathExplosion deathExplosion;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem waterParticleSystem;

    public void Die()
    {
        StopCompletly();
        DeactiveCollider();
        ShipTypeDeath();
        StartExplosions();
        StartSinking();
        StopEmitingWater();
    }

    void StopCompletly()
    {
        lockScripts.LockAndUnlockAll(false);
    }

    void DeactiveCollider()
    {
        myCollider.enabled = false;
    }

    void StartExplosions()
    {
        deathExplosion.enabled = true;
    }

    void StartSinking()
    {
        animator.SetTrigger("Death");
    }

    void StopEmitingWater()
    {
        waterParticleSystem.Pause();
    }

    protected abstract void ShipTypeDeath();


}
