using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour
{
    //This is a script for the Options scene in the Main Menu
    public GameObject clickedSound;

    public void BackToMenu()
    {
        clickedSound.GetComponent<AudioSource>().Play(); //add audio to the button
        Application.LoadLevel("Main Menu");
    }
}
