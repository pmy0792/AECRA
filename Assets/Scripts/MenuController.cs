using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Level to Load")]    
    public string _newGameLevel;
    private string levelToLoad;

    public void NewGameDialogYes()
    {
        ItemCollector.coins = 0;
        SceneManager.LoadScene(_newGameLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
