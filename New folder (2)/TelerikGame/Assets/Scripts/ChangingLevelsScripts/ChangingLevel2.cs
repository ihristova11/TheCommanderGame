using UnityEngine;
using System.Collections;

public class ChangingLevel2 : MonoBehaviour
{
    //Script for changing the LEVEL 1 to LEVEL 2
    public GameObject clickSound;
    public void MenuButtonClicked()
    {
        PlayerPrefs.SetInt("Level", 1);
        Application.LoadLevel("Main Menu");
    }

    public void NextLevelButtonClicked()
    {
        clickSound.GetComponent<AudioSource>().Play(); //add audio to the button
        PlayerPrefs.SetInt("Level", 2);
        Application.LoadLevel("Level2");
    }
}
