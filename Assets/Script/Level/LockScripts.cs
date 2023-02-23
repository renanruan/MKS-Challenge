using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScripts : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] ScriptsToLock;
    [SerializeField] GameObject[] GameObjectsToLock;

    private void Start()
    {
        LevelManeger.instance.SubscribeOnLevelStateChange(LockScriptsWhenNotPlaying);
    }

    void LockScriptsWhenNotPlaying(LEVE_STATE levelState)
    {
        LockAndUnlockAll(levelState == LEVE_STATE.PLAYING);
    }

    public void LockAndUnlockAll(bool lockScript)
    {
        foreach (MonoBehaviour script in ScriptsToLock)
        {
            script.enabled = lockScript;
        }

        foreach(GameObject gameObject in GameObjectsToLock)
        {
            gameObject.SetActive(lockScript);
        }
    }
}
