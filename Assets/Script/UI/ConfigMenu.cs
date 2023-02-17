using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    [SerializeField] Animator canvasAnimator;
    [SerializeField] InputField levelDurationInputField;
    [SerializeField] InputField enemySpawnInputField;

    private void Start()
    {
        levelDurationInputField.onValidateInput += ValidateNumericCharacter;
        enemySpawnInputField.onValidateInput += ValidateNumericCharacter;
    }

    char ValidateNumericCharacter(string input, int charIndex, char newCharacter)
    {
        if(newCharacter < '0' || newCharacter > '9')
        {
            return '\0';
        }

        return newCharacter;
    }

    public void LoadGameManegerInfo()
    {
        levelDurationInputField.text = GameManeger.GetLevelDuration().ToString();
        enemySpawnInputField.text = GameManeger.GetEnemySpawnTime().ToString();
    }

    public void SaveLevelDuration()
    {
        int newDuration = int.Parse(levelDurationInputField.text);

        if(newDuration < 60)
        {
            newDuration = 60;
            levelDurationInputField.text = newDuration.ToString();
        }
        else if(newDuration > 180)
        {
            newDuration = 180;
            levelDurationInputField.text = newDuration.ToString();
        }

        GameManeger.SetLevelDuration(newDuration);
    }

    public void SaveEnemySpawnTime()
    {
        int newSpawnTime = int.Parse(enemySpawnInputField.text);

        if (newSpawnTime < 2)
        {
            newSpawnTime = 2;
            enemySpawnInputField.text = newSpawnTime.ToString();
        }
        else if (newSpawnTime > 20)
        {
            newSpawnTime = 20;
            enemySpawnInputField.text = newSpawnTime.ToString();
        }

        GameManeger.SetEnemySpawnTime(newSpawnTime);
    }

    public void ReturnToMainMenu()
    {
        canvasAnimator.SetTrigger("SwitchMenus");
    }

}
