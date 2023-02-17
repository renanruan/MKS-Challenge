using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float speed;
    Vector3 direction;
    [SerializeField] int damage;
    DETECTABLE_LAYERS target;
    [SerializeField] float lifeSpawn;
    [SerializeField] GameObject explosionEffect;


    private void FixedUpdate()
    {
        Move();
        CheckTargetHit();
        ReduceLifeSpawn();
    }

    void Move()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void CheckTargetHit()
    {
        RaycastHit2D raycastHit2D = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, LayerMask.GetMask(target.ToString()));

        if(raycastHit2D.transform != null)
        {
            DoDamageToTarger(raycastHit2D.transform.parent.parent.gameObject);
            CreateExplosion();
            AutoDestroy();
        }
    }

    void DoDamageToTarger(GameObject targetHit)
    {
        targetHit.GetComponent<ShipHealth>().TakeDamage(damage);
    }

    void CreateExplosion()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }

    void ReduceLifeSpawn()
    {
        lifeSpawn -= Time.deltaTime;
        if(lifeSpawn <= 0)
        {
            AutoDestroy();
        }

    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public void SetTarget(DETECTABLE_LAYERS targetLayer)
    {
        this.target = targetLayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
