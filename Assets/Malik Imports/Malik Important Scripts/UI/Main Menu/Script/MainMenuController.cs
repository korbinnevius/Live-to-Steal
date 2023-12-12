using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TiltFive;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Option()
    {
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }

    public void Back()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;   
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
