using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Rect explosionArea;
    [SerializeField] float deathDuration = 1.7f;
    [SerializeField] float explosionDelay = 0.1f;

    float deathDurationTimer;
    float explosionDelayTimer;


    private void Start()
    {
        StartDeathDuration();
        StartExplosionDelay();
    }

    private void Update()
    {
        PassDeathDurationTimer();
        PassExplosionDelayTimer();
    }

    void StartDeathDuration()
    {
        deathDurationTimer = deathDuration;
    }

    void StartExplosionDelay()
    {
        explosionDelayTimer = explosionDelay + Random.Range(0,0.07f);
    }

    void PassDeathDurationTimer()
    {
        deathDurationTimer -= Time.deltaTime;
        if (deathDurationTimer < 0)
        {
            enabled = false;
        }
    }

    void PassExplosionDelayTimer()
    {
        explosionDelayTimer -= Time.deltaTime;
        if(explosionDelayTimer < 0)
        {
            StartExplosionDelay();
            CreateExplosion();
        }
    }

    void CreateExplosion()
    {
        Vector2 explosionPosition = new Vector3(Random.Range(explosionArea.xMin, explosionArea.xMax), Random.Range(explosionArea.yMin, explosionArea.yMax)) + transform.position;
        Instantiate(explosion, explosionPosition, transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(explosionArea.center, explosionArea.size);
    }
}
