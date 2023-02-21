using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeOnPlayer : MonoBehaviour
{
    [SerializeField] DetectWallAhead wallDetector;
    [SerializeField] ShipDeath shipDeath;
    [SerializeField] int damage;
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController explosionControler;

    private void FixedUpdate()
    {
        if (!wallDetector.HasClearPath())
        {
            Player.GetPlayer().gameObject.GetComponent<ShipHealth>().TakeDamage(damage);
            animator.runtimeAnimatorController = explosionControler;
            shipDeath.Die();
        }
    }
}
