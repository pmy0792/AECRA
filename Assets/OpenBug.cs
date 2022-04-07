using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScenes : MonoBehaviour
{
    public void OpenBugScene() 
    {
        SceneManager.LoadScene("HelpSectionScene");
    }

    public void OpenMainMenu() 
    {
        SceneManager.LoadScene("MenuItems");
    }

    public void OpenStartGame() 
    {
        SceneManager.LoadScene("PlayScene2");
    }

    public void OpenSettings() 
    {
        SceneManager.LoadScene("PlayScene2");
    }

    public void OpenTutorial() 
    {
        SceneManager.LoadScene("Tutorialscene");
    }
}
