using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICover : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool isLevelScene;
    [SerializeField] GameObject instructionPanel;
    public static UICover instance;

    string nextLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        HideUIInIntroScene();
    }

    void HideUIInIntroScene()
    {
        if (!isLevelScene)
        {
            animator.SetTrigger("HideUI");
        }
    }

    public void StartCounting()
    {
        if(isLevelScene && !instructionPanel.activeSelf)
        {
            LevelManeger.instance.StartCounting();
        }
    }

    public void ChangeLevel(string levelName)
    {
        nextLevel = levelName;
        animator.SetTrigger("ShowUI");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
