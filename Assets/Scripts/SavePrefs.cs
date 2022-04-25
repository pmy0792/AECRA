using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePrefs : MonoBehaviour
{
    public Vector3 position;
    [SerializeField] GameObject player;
    public int SceneIndex;

    public static SavePrefs instance;

    private void Awake() {

        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1)
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("x"),
            PlayerPrefs.GetFloat("y"),
            PlayerPrefs.GetFloat("z"));

            ItemCollector.coins = PlayerPrefs.GetInt("coins");

            PlayerPrefs.SetInt("Saved", 0);
            PlayerPrefs.Save();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save() 
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
        
        PlayerPrefs.SetInt("coins", ItemCollector.coins);
        PlayerPrefs.SetInt("loadScene", SceneIndex);

        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }
}
