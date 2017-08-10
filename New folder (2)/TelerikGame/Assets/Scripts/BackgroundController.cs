using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    //This is a script which makes the background looping effect
    private int numBG;
    private float distanceBG;
    public void Start()
    {
        var backgrounds = GameObject.FindGameObjectsWithTag("Background");

        this.numBG = backgrounds.Length;

        this.distanceBG = 5f;
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Background"))
        {

            var background = collider.gameObject;
            var backgroundPosition = background.transform.position;
            backgroundPosition.x += (numBG - 1) * this.distanceBG;
            background.transform.position = backgroundPosition;
        }
    }
}
