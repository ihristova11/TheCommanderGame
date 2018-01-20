using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour
{
    //This is a script which controls the player animations
    private Animator animator;

    //PLAYER STATE PARAMETERS
    const int idleState = 0;
    const int runState = 1;
    const int crouchState = 2;
    const int jumpState = 3;
    const int deadState = 4;
    int currentState2 = 0;
    int currentState = 0;

    public GameObject playerRunningSound;
    public GameObject jumpSound;
    private Transform firePoint;
    public bool isGettingShot = false;
    private bool isGettingShotPrev = false;
    private int prevState = 0;
    private bool jumpSoundFix = true;
    private bool jumpSoundFixPrev = true;
    
    public void Start()
    {

        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        this.animator = this.GetComponent<Animator>();
    }

    public void Update()
    {
        //Debug.Log(jumpSoundFix);
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && this.transform.position.y < 0)
        {
            jumpSoundFix = false;
        }   
        else
        {
            jumpSoundFix = true;
        }
        if(jumpSoundFixPrev == true && jumpSoundFix == false)
        {
            //Debug.Log("das");
            playerRunningSound.GetComponent<AudioSource>().Play();
        }
 
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.GetComponent<Weapon>().crouching = true;
        }
        else
        {
            this.GetComponent<Weapon>().crouching = false;
        }
            currentState2 = 0;
        
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            currentState2 = 1;
        }

        if (currentState2 == 1 && (Input.GetKeyDown(KeyCode.RightArrow) 
            || Input.GetKeyDown(KeyCode.LeftArrow)) && isGettingShot == false
            && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) 
        {
            playerRunningSound.GetComponent<AudioSource>().Play();
        }

        if (isGettingShot != isGettingShotPrev && isGettingShot == false)
        {
            //Debug.Log("asd");
            playerRunningSound.GetComponent<AudioSource>().Play();
        }
        

        if(currentState2 == 0 || isGettingShot || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            playerRunningSound.GetComponent<AudioSource>().Stop();
        }

        if(!isGettingShot && Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpSound.GetComponent<AudioSource>().Play();
        }

        if (animator.GetInteger(Animator.StringToHash("State")) != 4)
        {
            currentState = idleState;
            animator.SetInteger("State", idleState);
        }

        if(Input.anyKey && !isGettingShot)
        {
            
            //DOWN ARROW AND RIGHT ARROW/LEFT ARROW
            if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)))
            {
                currentState = runState;
                animator.SetInteger("State", runState);
            }

            if((Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)) 
                || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                currentState = jumpState;
                animator.SetInteger("State", jumpState);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                currentState = runState;
                animator.SetInteger("State", runState);
            }

            if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                currentState = jumpState;
                animator.SetInteger("State", jumpState);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                currentState = crouchState;
                animator.SetInteger("State", crouchState);
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                currentState = jumpState;
                animator.SetInteger("State", jumpState);
            }

            if(Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
            {
                currentState = crouchState;
                animator.SetInteger("State", crouchState);
            }
        }
        isGettingShotPrev = isGettingShot;
        jumpSoundFixPrev = jumpSoundFix;
    }
}
