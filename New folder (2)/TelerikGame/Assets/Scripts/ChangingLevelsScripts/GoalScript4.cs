using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalScript4 : MonoBehaviour
{
    //This script changes the LEVEL 3 to LEVEL 4 when the monsters are killed
    //and selects the amount of monsters you need to kill to reach the next level
    public int monstersKilled = 0;
    public int monstersKillLimit = 5;
    private GameObject goalText;
    private Text textGoal;
    private int difficulty;

    public void Start()
    {
        goalText = GameObject.Find("Goal Text");
        textGoal = goalText.GetComponent<Text>();

        difficulty = PlayerPrefs.GetInt("Difficulty");
        if (difficulty == 1)
        {
            monstersKillLimit = 10;
        }
    }

    public void Update()
    {
        textGoal.text = "Monsters Killed:" + monstersKilled.ToString() + "/" + monstersKillLimit.ToString();

        if (monstersKilled == monstersKillLimit)
        {
            Application.LoadLevel("NextLevel4");
        }
    }
}
