using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour
{
    //This is a script which deals with the damage 
    public float moveSpeed = 6f;
    private Rigidbody2D rigid;
    private bool _facingRight;

    public int damage = 25;
    public Material bulletMaterial;

    public Color startColor;
    public Color endColor1;
    public Color endColor2;
    public Color endColor3;
    public Color endColor4;

    public void Start()
    {
        this.GetComponent<LineRenderer>().material = bulletMaterial;
        this.GetComponent<LineRenderer>().SetColors(startColor, endColor1);
        
        _facingRight = GameObject.Find("Player").GetComponent<PlayerMovementController>().facingRight;
        if(_facingRight == false)
        {
            this.transform.Rotate(new Vector3(0, 1, 0), 180);
        }
        this.rigid = this.GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (_facingRight == true)
        {
            rigid.velocity = new Vector2(moveSpeed, this.rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(-moveSpeed, this.rigid.velocity.y);
        }

    }

    //Destroying the Enemy 
    //Dealing damage
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Enemy")
        {
            GameObject.Find("Enemy").GetComponent<EnemyAnimationController>().health =
                GameObject.Find("Enemy").GetComponent<EnemyAnimationController>().health - damage;

            this.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject, 0.5f);
        }

        Destroy(this.gameObject, 1.5f);
    }
}
