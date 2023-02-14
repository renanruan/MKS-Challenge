using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] GameObject ShipUIPrefab;
    [SerializeField] Transform shipToFollow;
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
        shipUI.SetHealthPercentage(currentHealth / maxHealth);
    }
}
