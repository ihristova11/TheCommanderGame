using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    //This is a script 
    public float fireRate = 0;
    public float Damage = 10;

    public LayerMask whatToHit;

    public Transform bulletTrailPrefab;
    public Transform yellowEnemyPrefab;
    public Transform redEnemyPrefab;
    public Transform blueEnemyPrefab;
    public Transform brownEnemyPrefab;

    public AudioClip gun;

    private float range = 2f;

    private Rigidbody2D rigid;

    private float timeToRate = 0;
    Transform firePoint;

    private bool _facingRight;
    private bool coolingDown = false;
    public bool crouching = false;
    public GameObject gunSound;
    public void Awake()
    {
        //Instanting the different prefabs
        float randomValue = Random.Range(3, 8);

        if (GameObject.Find("Level 1") != null)
        {
            Instantiate(brownEnemyPrefab, new Vector2(this.transform.position.x + 9 + randomValue, -0.5f), Quaternion.identity);
        }

        if (GameObject.Find("Level 2") != null)
        {
            Instantiate(blueEnemyPrefab, new Vector2(this.transform.position.x + 9 + randomValue, -0.5f), Quaternion.identity);
        }

        if (GameObject.Find("Level 3") != null)
        {
            Instantiate(yellowEnemyPrefab, new Vector2(this.transform.position.x + 9 + randomValue, -0.5f), Quaternion.identity);
        }

        if (GameObject.Find("Level 4") != null)
        {
            Instantiate(redEnemyPrefab, new Vector2(this.transform.position.x + 9 + randomValue, -0.5f), Quaternion.identity);
        }

        this.rigid = this.GetComponent<Rigidbody2D>();
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No fireRate?!");
        }
    }

    //cooling down
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.25f);
        coolingDown = false;
    }

    public void Update()
    {

        if (fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > timeToRate)
            {
                timeToRate = Time.time + 1 / fireRate;
                Shoot();

            }
        }
    }

    //Function about shooting 
    public void Shoot()
    {
        if (crouching == false)
        {
            Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
            Vector2 direction = new Vector2(rigid.velocity.x + 1.5f, firePoint.position.y);
            RaycastHit2D hit = Physics2D.Raycast(firePointPosition, direction - firePointPosition, 75f, whatToHit);
            Effect();
            gunSound.GetComponent<AudioSource>().Play();
        }
    }
    //Function which instantiates the bullet prefab
    public void Effect()
    {
        if (coolingDown == false)
        {

            _facingRight = GameObject.Find("Player").GetComponent<PlayerMovementController>().facingRight;
            if (_facingRight)
            {
                Instantiate(bulletTrailPrefab, new Vector2(firePoint.transform.position.x + 1f, firePoint.transform.position.y), firePoint.rotation);
            }
            else
            {
                Instantiate(bulletTrailPrefab, new Vector2(firePoint.transform.position.x - 1f, firePoint.transform.position.y), firePoint.rotation);
            }
            StartCoroutine(CoolDown()); //start cool down
            coolingDown = true;
        }
    }
}