using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsScreen : MonoBehaviour
{
    public Toggle fullscreenTog;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedRes;
    public TMP_Text resolutionLabel;

    // Start is called before the first frame update
    async void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        bool foundRes = false;
        for (int i=0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedRes = i;
                UpdateResLabel();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        selectedRes--;
        if(selectedRes < 0)
        {
            selectedRes = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedRes++;
        if(selectedRes > resolutions.Count-1)
        {
            selectedRes = resolutions.Count-1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedRes].horizontal.ToString() + " x " + resolutions[selectedRes].vertical.ToString();
    }

    public void Apply()
    {
        Screen.fullScreen = fullscreenTog.isOn;
        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical, fullscreenTog.isOn);
    }
} 

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
