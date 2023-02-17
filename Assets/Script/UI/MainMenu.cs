using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void OpenConfigMenu()
    {
        canvasAnimator.SetTrigger("SwitchMenus");
    }
}
