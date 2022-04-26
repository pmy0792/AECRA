using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    public static int coins = 0;

    [SerializeField] private TMP_Text coinsText;

    [SerializeField] private AudioSource coinCollectionSoundEffect;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start() {
        coins = 0;
        PlayerPrefs.SetInt("collect", 0); 
    }
    private void Update() {
        
        coinsText.text = "Coins: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GameObject objectToDestroy = collision.gameObject;

            coinCollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            
            PlayerPrefs.SetInt("collect", 1);
        }

        else if (collision.gameObject.CompareTag("Vaccine"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Herb"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
        }
    }
}