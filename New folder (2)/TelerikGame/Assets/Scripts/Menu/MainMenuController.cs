using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class MainMenuController : MonoBehaviour
{
    //This script is used to redirect the player to specific scenes in the Main Menu
    public void PlayButtonClicked()
    {
        Application.LoadLevel("LoadingScene");
    }
    public void ExitButtonClicked()
    {
        Application.Quit();
    }

    public void Start()
    {
        PlayerPrefs.SetInt("Level", 1);
    }
}
