using UnityEngine;
using System.Collections;

public class HealthBoxCollision : MonoBehaviour
{
    //This is a script which is used to ignore collision with the health box
    public void Start()
    {
        Physics2D.IgnoreCollision(GameObject.Find("HealthBox").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }
}
