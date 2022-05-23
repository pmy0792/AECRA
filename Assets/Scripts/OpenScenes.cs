using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScenes : MonoBehaviour
{
    private void Update() {
    }
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
        PlayerPrefs.SetInt("Saved", 0);
        SceneManager.LoadScene("PlayScene2");
    }

    public void OpenSettings() 
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void OpenTutorial() 
    {
        SceneManager.LoadScene("Tutorialscene");
    }

    public void OpenAbout() 
    {
        SceneManager.LoadScene("AboutDevs");
    }

    public void OpenNewLvl() 
    {
        PlayerPrefs.SetInt("coins", ItemCollector.coins);
        SceneManager.LoadScene("LVL1");        
    }
}
