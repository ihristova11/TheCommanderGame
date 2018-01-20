using UnityEngine;
using System.Collections;

public class LoadingScreenScript : MonoBehaviour
{
    //This script shows the Loading screen of the game when Play button is clicked
    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("Level1");
    }

    public void Start()
    {
        StartCoroutine(StartLevel());
    }
}
