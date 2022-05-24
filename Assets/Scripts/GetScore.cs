using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetScore : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;

    private void Start() {
        GetSc();
    }
    public void GetSc()
    {
        if(PlayerPrefs.GetInt("coins") > 0)
        {
            ItemCollector.coins = PlayerPrefs.GetInt("coins");
            coinsText.text = ItemCollector.coins.ToString();
        } 
    }
}
