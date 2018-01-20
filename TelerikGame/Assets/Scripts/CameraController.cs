using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //This is a script attached to the camera 
    //The purpose is to follow the player 
    public GameObject player;
    public GameObject border;
    private float distance = 3.85f;

    public void Start()
    {
        distance = border.GetComponent<StopColliderController>().distance;
    }
    public void Update()
    {
        CameraMovement();
    }


    public void CameraMovement()
    {

        if (Input.GetKey(KeyCode.RightArrow) && (player.transform.position.x - border.transform.position.x) > distance)
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && (player.transform.position.x - border.transform.position.x) > distance)
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        } 

        //if the ESCAPE button is pressed, go to Main Menu scene
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("Main Menu");
        }
    }
}

