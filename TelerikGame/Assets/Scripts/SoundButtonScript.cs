using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundButtonScript : MonoBehaviour
{
    //This is a script for the Sound button in the Main Menu
    public int sound = 1;

    public void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            this.GetComponent<Toggle>().isOn = false;
        }
        else
        {
            this.GetComponent<Toggle>().isOn = true;
        }

        if (this.GetComponent<Toggle>().isOn == false)
        {
            sound = 0;
        }
        else
        {
            sound = 1;
        }
        PlayerPrefs.SetInt("Sound", sound);
    }


    public void ToggleSound()
    {
        if (sound == 0)
        {
            sound = 1;
        }
        else if (sound == 1)
        {
            sound = 0;
        }
        PlayerPrefs.SetInt("Sound", sound);
    }

    public void Update()
    {
        if (sound == 0)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
}
