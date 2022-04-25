using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private TMP_Text coinsText;

    [SerializeField] private AudioSource coinCollectionSoundEffect;
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinCollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
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