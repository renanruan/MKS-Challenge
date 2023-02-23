using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] GameObject ShipUIPrefab;
    [SerializeField] Transform shipToFollow;
    [SerializeField] ShipHealthStages[] shipHealthStages;
    [SerializeField] ShipDeath shipDeath;
    ShipUI shipUI;

    private void Start()
    {
        currentHealth = maxHealth;
        InstantiateUI();
    }

    void InstantiateUI()
    {
        shipUI = GameObject.Instantiate(ShipUIPrefab, ShipUICanvas.GetCavas()).GetComponent<ShipUI>();
        shipUI.SetShipToFollow(shipToFollow);
        
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageTaken);
        float healthPercentage = currentHealth / maxHealth;
        shipUI.SetHealthPercentage(healthPercentage);
        foreach(ShipHealthStages shipHealthStages in shipHealthStages)
        {
            shipHealthStages.SetPercentage(healthPercentage);
        }

        if(currentHealth == 0)
        {
            shipDeath.Die();
        }

        LevelDetrits.DamageAtPoint(transform.position);
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
