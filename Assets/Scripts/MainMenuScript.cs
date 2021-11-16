using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainMenuUI;
    public GameObject ControlsMenuUI;
    void Start()
    {
        MainMenuUI.SetActive(true);
        ControlsMenuUI.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ControlsButton()
    {
        MainMenuUI.SetActive(false);
        ControlsMenuUI.SetActive(true);
    }
    public void BackButton()
    {
        MainMenuUI.SetActive(true);
        ControlsMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
