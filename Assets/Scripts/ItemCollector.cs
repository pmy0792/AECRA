using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    public static int coins = 0;

    public bool collecting_vaccine;
    public bool collecting_herb;
    public bool collecting_coin;
    float timer;
    GameObject vaccine_effect;

    [SerializeField] private TMP_Text coinsText;

    [SerializeField] private AudioSource coinCollectionSoundEffect;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start() {
        coins = 0;
        vaccine_effect=transform.Find("TextEffect").gameObject;
        collecting_coin=false;
        collecting_vaccine=false;
        collecting_herb=false;
        PlayerPrefs.SetInt("collect", 0); 
        timer=0;
    }
    private void Update() {
        
        coinsText.text = "Score: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collecting_coin=true;
            coinCollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins=coins+5;
            
            PlayerPrefs.SetInt("collect", 1);
            collecting_coin=false;
        }

        else if (collision.gameObject.CompareTag("Vaccine"))
        {
            collecting_vaccine=true;
            vaccine_effect.SetActive(true);
            
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            
            coins=coins+15;
            
            PlayerPrefs.SetInt("collect", 1);
        }

        else if (collision.gameObject.CompareTag("Herb"))
        {
            collecting_herb=true;
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            collecting_herb=false;

            coins=coins+10;
            
            PlayerPrefs.SetInt("collect", 1);
        }
    }
}