using UnityEngine;
using System.Collections;

public class ChangingLevel3 : MonoBehaviour
{
    //Script for changing the LEVEL 2 to LEVEL 3
    public GameObject clickSound;
    public void MenuButtonClicked()
    {
        PlayerPrefs.SetInt("Level", 1);
        Application.LoadLevel("Main Menu");
    }

    public void NextLevelButtonClicked()
    {
        clickSound.GetComponent<AudioSource>().Play();//add audio to the button
        PlayerPrefs.SetInt("Level", 3);
        Application.LoadLevel("Level3");
    }
}
