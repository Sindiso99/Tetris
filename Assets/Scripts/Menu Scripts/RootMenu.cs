using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject currentUI;

    void Update()
    {
        checkForPaused();
    }
    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame ()
    {
        Debug.Log("Scionara, Space Cowboy");
        Application.Quit();
    }

    public void ResumeGame ()
    {
        currentUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void PauseGame()
    {
        currentUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void QuitLevel()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        Debug.Log("U gave up");
        SceneManager.LoadScene(0);
    }

    private void checkForPaused()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 & Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }
}
