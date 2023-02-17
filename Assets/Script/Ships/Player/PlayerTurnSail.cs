using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnSail : MonoBehaviour
{
    [SerializeField] float maxAngle;

    public void SetTurnInput(float input)
    {
        transform.localRotation = Quaternion.Euler(0, 0, maxAngle * input);
    }
}
