using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DifficultyButtonScript : MonoBehaviour
{
    //This is a script for the Options menu difficulty
    private int difficulty;

    public void Awake()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 1)
       {
           this.GetComponent<Toggle>().isOn = true;
       }
       else
       {
           this.GetComponent<Toggle>().isOn = false;
       }
        if (this.GetComponent<Toggle>().isOn == false)
        {
            difficulty = 0;
        }
        else
        {
            difficulty = 1;
        }
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }


    public void ToggleDifficulty()
    {
        if(difficulty == 0)
        {
            difficulty = 1;
        }
        else if(difficulty == 1)
        {
            difficulty = 0;
        }
        PlayerPrefs.SetInt("Difficulty", difficulty);
    }
}
