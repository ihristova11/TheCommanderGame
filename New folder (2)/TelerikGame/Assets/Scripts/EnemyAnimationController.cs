using UnityEngine;
using System.Collections;

public class EnemyAnimationController : MonoBehaviour
{
    //This is a script which controls the enemy animations

    public int health = 100;
    public int damage = 25;
    private int counter = 0;
    private int counter2 = 0;
    private int counter3 = 0;
    
    private Animator animator;
    //initializing the prefabs
    public Transform brownEnemyPrefab;
    public Transform blueEnemyPrefab;
    public Transform yellowEnemyPrefab;
    public Transform redEnemyPrefab;

    public GameObject player;
    private GameObject leftBorder;
    
    public float hitAnimationDuration = 1f;
    public float deadFallDelay = 0.5f;
    
    public float hitDistance = 0.1f;
    private bool isAlive = true;

    public void Start()
    {
        leftBorder = GameObject.Find("StopCollider");
        this.GetComponent<EnemyMovementController>().speed = 0.025f;
        this.gameObject.name = "Enemy";
        health = 100;
        this.animator = this.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }
    
    IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(hitAnimationDuration);
        this.GetComponent<EnemyMovementController>().isShooting = false;
        animator.SetBool("isShooting", false);
        player.GetComponent<PlayerMovementController>().isGettingShot = false;
        player.GetComponent<PlayerAnimationController>().isGettingShot = false;
    }

    IEnumerator DeadFall()
    {
        yield return new WaitForSeconds(deadFallDelay);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.25f);
    }

    public void Update()
    {
        if(this.transform.position.x < leftBorder.transform.position.x && counter3 == 0 && isAlive)
        {
            health = 0;
            GameObject.Find("Goal").GetComponent<GoalScript>().monstersKilled--;
            counter3++;
        }

        if(counter3 == 2)
        {
            counter3 = 2;
        }

        if(Mathf.Abs(player.transform.position.x - this.transform.position.x) < hitDistance && this.transform.position.x > player.transform.position.x)
        {
            if (counter2 == 0 && player.transform.position.y <= 0 && isAlive)
            {
                player.GetComponent<PlayerMovementController>().isGettingShot = true;
                player.GetComponent<PlayerAnimationController>().isGettingShot = true;
                animator.SetBool("isShooting", true);
                this.GetComponent<AudioSource>().Play();
                player.GetComponent<HealthLogic>().currentHealth = player.GetComponent<HealthLogic>().currentHealth - damage;
                counter2++;
                this.GetComponent<EnemyMovementController>().isShooting = true;

            }
            StartCoroutine(AnimationWait());
        }
        else
        {
            animator.SetBool("isShooting", false);
            this.GetComponent<EnemyMovementController>().isShooting = false;
        }


        if(health <= 0)
        {
            isAlive = false;
            this.GetComponent<EnemyMovementController>().speed = 0;
            animator.SetBool("isDead", true);

            Destroy(this.gameObject, 2);
                        
            if (counter == 0)
            {
                GameObject.Find("Goal").GetComponent<GoalScript>().monstersKilled++;
                StartCoroutine(DeadFall());
                float randomValue = Random.Range(15, 22);

                if (GameObject.Find("Level 1") != null)
                {
                    Instantiate(brownEnemyPrefab, new Vector2(this.transform.position.x + randomValue, -0.5f), Quaternion.identity);
                }

                if (GameObject.Find("Level 2") != null)
                {
                    Instantiate(blueEnemyPrefab, new Vector2(this.transform.position.x + randomValue, -0.5f), Quaternion.identity);
                }

                if (GameObject.Find("Level 3") != null)
                {
                    Instantiate(yellowEnemyPrefab, new Vector2(this.transform.position.x + randomValue, -0.5f), Quaternion.identity);
                }

                if (GameObject.Find("Level 4") != null)
                {
                    Instantiate(redEnemyPrefab, new Vector2(this.transform.position.x + randomValue, -0.5f), Quaternion.identity);
                }

            }
            if (counter > 2)
            {
                counter = 2;
            }
            counter++;
        }
    }
}
