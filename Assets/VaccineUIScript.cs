using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaccineUIScript : MonoBehaviour
{
    public static int vaccine;
    // Start is called before the first frame update
    void Start()
    {
        vaccine=0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "VACCINE: "+ vaccine.ToString();
    }
}
