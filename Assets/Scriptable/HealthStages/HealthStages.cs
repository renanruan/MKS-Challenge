using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/HealthStages")]
public class HealthStages : ScriptableObject
{
    [SerializeField] Sprite[] spritesStages;

    public int GetNumberOfStages()
    {
        return spritesStages.Length;
    }

    public Sprite GetStage(int stageID)
    {
        return spritesStages[stageID];
    }
}
