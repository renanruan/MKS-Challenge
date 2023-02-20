using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PointsEvent(int totalpoints);

public class LevelPointsManeger : MonoBehaviour
{
    public static LevelPointsManeger instance;

    int currentPoints = 0;
    event PointsEvent pointsAdded;

    private void Awake()
    {
        instance = this;
    }

    public void AddPoints(int newPoints)
    {
        currentPoints += newPoints;
        pointsAdded?.Invoke(currentPoints);
    }

    public void SubscribeOnPointsAddedEvent(PointsEvent pointsEvent)
    {
        pointsAdded += pointsEvent;
    }

    public int GetTotalPoints()
    {
        return currentPoints;
    }
}
