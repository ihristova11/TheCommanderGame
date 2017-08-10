using UnityEngine;
using System.Collections;

public class HealthBoxScript : MonoBehaviour
{
    //This is a script which changes the health box name in order to be used properly
    public void Start()
    {
        this.gameObject.name = "HealthBox";
    }
}
