using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] Animator myAnimator;
    [SerializeField] Text WinLoseText;
    [SerializeField] Text ScoreText;

    private void Start()
    {
        LevelManeger.instance.SubscribeOnLevelStateChange(CheckEndGame);
    }

    void CheckEndGame(LEVE_STATE levelState)
    {
        if(levelState == LEVE_STATE.FINISHED_LEVEL)
        {
            OnEndGame();
        }
    }

    void OnEndGame()
    {
        if (Player.IsPlayerAlive())
        {
            OnWin();
            ShowPanel("Win");
        }
        else
        {
            OnLose();
            ShowPanel("Lose");
        }
        UpdateScore();

    }

    void OnWin()
    {
        WinLoseText.text = "Você venceu!";
    }

    void OnLose()
    {
        WinLoseText.text = "Você perdeu";
    }

    void UpdateScore()
    {
        ScoreText.text = "Pontuação\n\r" + LevelPointsManeger.instance.GetTotalPoints().ToString();
    }

    void ShowPanel(string WinOrLose)
    {
        myAnimator.SetTrigger(WinOrLose);
    }

    public void RestartLevel()
    {
        UICover.instance.ChangeLevel("LevelScene");
    }

    public void ReturnToMainMenu()
    {
        UICover.instance.ChangeLevel("IntroScene");
    }
}
