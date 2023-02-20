using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : ShipDeath
{
    [SerializeField] int pointsToAdd = 0;

    protected override void ShipTypeDeath()
    {
        AddPointsToScore();
    }

    void AddPointsToScore()
    {
        if (pointsToAdd > 0)
        {
            LevelPointsManeger.instance.AddPoints(pointsToAdd);
        }
    }
}
