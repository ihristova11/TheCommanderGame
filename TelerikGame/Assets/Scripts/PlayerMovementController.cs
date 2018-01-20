using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    //This is a script which controls the player movement 
    public bool facingRight; //player facing direction
    
    private float speed = 2.5f; //player run speed
    private float jumpSpeed = 6f; //player jump speed
    private Rigidbody2D rigid;
    public bool isDead = false;

    public bool isGettingShot = false;
    public void Start()
    {
        facingRight = true;
        this.rigid = this.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {

        if (!isGettingShot && !isDead)
        {
            //PLAYER MOVE LEFT
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                FlipLeft();
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                // rigid.velocity = new Vector2(-speed, rigid.velocity.y);
            }

            //PLAYER JUMP
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
            }

            //RUN AND JUMP
            //RUN AND JUMP
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0.005f, 0.009f, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                FlipRight();
                //transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //PLAYER MOVE RIGHT
            {
                FlipRight();
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

        }
    }


    //------------------------
    //FLIPPING THE PLAYER LEFT
    //------------------------
    public void FlipLeft()
    {
        facingRight = false;

        Vector3 theScale = transform.localScale;
        theScale.x = -1;
        transform.localScale = theScale;
    }

    //------------------------
    //FLIPPING THE PLAYER RIGHT
    //------------------------
    public void FlipRight()
    {
        facingRight = true;

        Vector3 theScale = transform.localScale;
        theScale.x = 1;
        transform.localScale = theScale;
    }
}
