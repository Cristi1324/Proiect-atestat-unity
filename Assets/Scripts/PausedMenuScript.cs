using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    private float timespeed = 1;
    public GameObject pausedMenuUI;
    public GameObject GameOverMenuUI;
    void Start()
    {
        pausedMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    void Resume()
    {
        pausedMenuUI.SetActive(false);
        Time.timeScale = timespeed;
        GameIsPaused = false;
    }
    void Pause()
    {
        pausedMenuUI.SetActive(true);
        timespeed=Time.timeScale;
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void ResumeButton()
    {
        Resume();
    }
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
