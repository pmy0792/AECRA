using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class HPbarScript : MonoBehaviour
{
    public static Slider sl;
    public Slider hp;

    void Start()
    {
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sl.value==0.0f)
        {
            if (PlayerMovement.GetSize() > 1)
            {
                PlayerMovement.RemoveLife();
                sl.value = 1;
                hp.value = 100f;
            }    
            else{
                PlayerMovement.RemoveLife();
            }
        
            
        }
    }
}
