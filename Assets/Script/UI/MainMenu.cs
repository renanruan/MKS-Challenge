using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;

    public void StartGame()
    {
        UICover.instance.ChangeLevel("LevelScene");
    }

    public void OpenConfigMenu()
    {
        canvasAnimator.SetTrigger("SwitchMenus");
    }
}
