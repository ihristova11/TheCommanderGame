using UnityEngine;
using System.Collections;

public class StopColliderController : MonoBehaviour
{
    //This is a script for the collider which makes the player not go to the left out of the camera border
    public GameObject player;
    public float distance = 3.85f;

    private Transform cameraCoordinate;

    public void Start()
    {
        this.cameraCoordinate = Camera.main.GetComponent<Transform>();
    }
    public void Update()
    {
        //The StopCollider is following the Main Camera
        StopGoingBack();
    }

    public void StopGoingBack()
    {
        if (Input.GetKey(KeyCode.RightArrow) && (player.transform.position.x - this.transform.position.x) > distance)
        {
            this.transform.position = new Vector2(player.transform.position.x - distance, this.transform.position.y);
        }
    }
}