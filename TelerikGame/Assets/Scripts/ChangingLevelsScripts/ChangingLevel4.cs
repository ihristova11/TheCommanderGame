using UnityEngine;
using System.Collections;

public class ChangingLevel4 : MonoBehaviour
{
    //Script for changing the LEVEL 3 to LEVEL 4
    public GameObject clickSound;
    public void MenuButtonClicked()
    {
        PlayerPrefs.SetInt("Level", 1);
        Application.LoadLevel("Main Menu");
    }

    public void NextLevelButtonClicked()
    {
        clickSound.GetComponent<AudioSource>().Play(); //add audio to the button
        PlayerPrefs.SetInt("Level", 4);
        Application.LoadLevel("Level4");
    }
}
