using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthLogic : MonoBehaviour
{
    //This is a script which is used for making the health logic
    public float speed;
    public float coolDown;
   
    private bool onCD;
    
    public RectTransform healthTransform;
    public Animator animator;
    
    private float cachedY;
    private float minXValue;
    private float maxXValue;

    public GameObject healthBoxSound;
    public GameObject deadSound;

    public int currentHealth;
    public int maxHealth = 100;

    public Text healthText;
    public Image visualHealth;

    private int CurrentHealth
    {
        get { return currentHealth; }
        set 
        { 
            currentHealth = value;
            HandledHealth();
        }
        
    }
    public void Start()
    {
        maxXValue = healthTransform.position.x;
        minXValue = healthTransform.position.x - healthTransform.rect.width;
        currentHealth = maxHealth;
        onCD = false;
    }
    //DeadDelay is not used yet
    IEnumerator DeadDelay()
    {
        yield return new WaitForSeconds(2f);
    }

    public void Update()
    {

        cachedY = healthTransform.position.y;
        if(currentHealth <= 0)
        {
            animator.SetInteger("State", 4);
            deadSound.GetComponent<AudioSource>().Play();
            currentHealth = 0;
            StartCoroutine(DeadDelay());
            this.GetComponent<PlayerMovementController>().isDead = true;
            Application.LoadLevel("GameOver");
        }
        HandledHealth();
    }

    public void HandledHealth()
    {
        healthText.text = "Health: " + currentHealth;

        float currentXValue = MapValues(currentHealth, 0, maxHealth, minXValue, maxXValue);

        healthTransform.position = new Vector3(currentXValue, cachedY);

        if(currentHealth > maxHealth / 2) // then I have more than 50% health 
        {
            visualHealth.color = new Color32((byte)MapValues(currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
        }
        else // less then 50% health
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
        }
    }
    public float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

    //If the player has collided with health box, his Health will be 100
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "HealthBox")
        {
            healthBoxSound.GetComponent<AudioSource>().Play();
            currentHealth = 100;
            Destroy(collider.gameObject);
        }

    }
}