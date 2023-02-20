using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : ShipDeath
{
    protected override void ShipTypeDeath()
    {
        LevelManeger.instance.FinishPlaying();
    }
}
