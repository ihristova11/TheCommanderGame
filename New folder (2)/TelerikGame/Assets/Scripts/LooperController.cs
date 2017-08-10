using UnityEngine;
using System.Collections;

public class LooperController : MonoBehaviour 
{
    //This is a script for the object which needs to follow the player
    //Objects like Floor and Ceiling
    private float offsetX;
    public GameObject player;

    public void Start()
    {
        this.offsetX = this.transform.position.x
            - this.player.transform.position.x;
    }

    public void Update()
    {
        var position = this.transform.position;
        position.x = this.player.transform.position.x;
        this.transform.position = position;
    }
}
