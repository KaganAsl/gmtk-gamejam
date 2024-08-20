using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup TutorialPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Tutorial()
    {
        TutorialPanel.alpha = 1;
        TutorialPanel.blocksRaycasts = true;
    }

    public void Back()
    {
        TutorialPanel.alpha = 0;
        TutorialPanel.blocksRaycasts = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
