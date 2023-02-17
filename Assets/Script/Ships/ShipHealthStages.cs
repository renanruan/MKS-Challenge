using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthStages : MonoBehaviour
{
    [SerializeField] HealthStages healthStages;
    [SerializeField] SpriteRenderer spriteRenderer;

    int lifeStages;

    private void Start()
    {
        lifeStages = healthStages.GetNumberOfStages() - 1;
    }

    public void SetPercentage(float percentage)
    {
        spriteRenderer.sprite = healthStages.GetStage(lifeStages - Mathf.CeilToInt(lifeStages * (percentage)));
    }
}

