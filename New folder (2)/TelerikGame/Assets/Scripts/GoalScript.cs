using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    //This script changes the LEVEL 4 to CongratsScene when the monsters are killed and the player has won
    //and selects the amount of monsters you need to kill to reach the next level
    public int monstersKilled = 0;
    public int monstersKillLimit = 5;
    private int difficulty;
    
    private GameObject goalText;
    private Text textGoal;

    public void Start()
    {
        goalText = GameObject.Find("Goal Text");
        textGoal = goalText.GetComponent<Text>();

        difficulty = PlayerPrefs.GetInt("Difficulty");
        if(difficulty == 1)
        {
            monstersKillLimit = 10;
        }
    }

    public void Update()
    {
        textGoal.text = "Monsters Killed: " + monstersKilled.ToString() + "/" + monstersKillLimit.ToString();

        if (monstersKilled == monstersKillLimit)
        {
            if (GameObject.Find("Level 1"))
            {
                Application.LoadLevel("NextLevel2");
            }
            if(GameObject.Find("Level 2"))
            {
                Application.LoadLevel("NextLevel3");
            }
            if(GameObject.Find("Level 3"))
            {
                Application.LoadLevel("NextLevel4");
            }

            if(GameObject.Find("Level 4"))
            {
                Application.LoadLevel("CongratsScene");
            }
        }
    }
}
