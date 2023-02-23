using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsCover : MonoBehaviour
{
    void Start()
    {
        if (GameManeger.IsFirstPlay())
        {
            GameManeger.PlayFirstPlay();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            LevelManeger.instance.StartCounting();
            gameObject.SetActive(false);
        }
    }


}
