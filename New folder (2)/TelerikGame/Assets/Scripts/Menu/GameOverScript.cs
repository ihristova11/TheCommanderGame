using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    //This script is used when the player is dead to show the Game Over scene
    //and select the specific level to be played again
    public GameObject clickSound;
    public void MenuButtonClicked()
    {
        clickSound.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("Level", 1);
        Application.LoadLevel("Main Menu");
    }

    public void PlayAgainButtonClicked()
    {
        clickSound.GetComponent<AudioSource>().Play();
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            Application.LoadLevel("Level1");
        }
        else if (PlayerPrefs.GetInt("Level") == 2)
        {
            Application.LoadLevel("Level2");
        }
        else if (PlayerPrefs.GetInt("Level") == 3)
        {
            Application.LoadLevel("Level3");
        }
        else if (PlayerPrefs.GetInt("Level") == 4)
        {
            Application.LoadLevel("Level4");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            Application.LoadLevel("Level1");
        }
    }
}
