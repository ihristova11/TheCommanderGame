using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour
{
    //This is a script for the buttons of the Main Menu which appears in a specific way
    public bool mouseIsOver = false;
    private Image images;
    public float speed = 2f;
    public Sprite clicked;
    public float topLimit = 5f;
    private Sprite current;

    public GameObject clickSound;
    public void Start()
    {
        images = gameObject.GetComponent<Image>();
        current = images.sprite;
    }
    public void MouseEnter()
    {
        mouseIsOver = true;
    }

    public void MouseExit()
    {
        mouseIsOver = false; 
    }

    public void Update()
    {
        if(mouseIsOver && this.transform.position.y < topLimit)
        {
            this.transform.Translate(new Vector3(0, speed, 0));
        }
        else if(!mouseIsOver && this.transform.position.y > -26)
        {
            this.transform.Translate(new Vector3(0, -speed, 0));
        }
    }

    IEnumerator ClickEffect()
    {
        
        yield return new WaitForSeconds(0.2f);
        if (this.gameObject.name == "Play")
        {
            Application.LoadLevel("LoadingScene");
        } 
        
        if (this.gameObject.name == "Options")
        {
            Application.LoadLevel("Options");
        }
        if(this.gameObject.name == "Exit")
        {
            Application.Quit();
        }
        images.sprite = current;
    }
    public void MouseClick()
    {
        clickSound.GetComponent<AudioSource>().Play();
        images.sprite = clicked;
        StartCoroutine(ClickEffect());
    }
}
