using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteCanvas;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] bool isLast = false;

    int numberOfAttackers = 0;
    bool levelTimeFinished = false;
    bool gameOver = false;

    private void Start()
    {
        gameOver = false;

        GetComponent<AudioSource>().volume = PlayerPrefsController.GetMasterVolume();
        levelCompleteCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void LevelTimerFinished()
    {
        levelTimeFinished = true;
        StopSpawners();
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimeFinished)
        {
            StartCoroutine(HandleWin());
        }

    }

    IEnumerator HandleWin()
    {
        levelCompleteCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        if (isLast)
            FindObjectOfType<LevelLoader>().LoadMainMenu();
        else
            FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLose()
    {
        gameOver = true;
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
            spawner.StopSpawn();
    }
}
