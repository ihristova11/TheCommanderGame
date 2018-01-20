using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour
{
    //This is a script which controls the enemy movement
    public float speed = 0.025f;

    public float positionY = -1.1f;

    public bool isShooting = false;

    public void Start()
    {
        this.transform.position = new Vector2(this.transform.position.x, positionY);
    }
    public void Update()
    {
        if (isShooting == false)
        {
            this.transform.position = new Vector2(this.transform.position.x - speed, this.transform.position.y);
        }
    }
}