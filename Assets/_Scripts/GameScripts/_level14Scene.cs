using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _level14Scene : MonoBehaviour{


    // The sprite variable contains sprites of the background images

    public Sprite a;
    public Sprite b;
    public Sprite c;
    public Sprite d;
    public Sprite e;
    public Sprite f;
    public Sprite g;
    public Sprite h;
    public Sprite i;
    public Sprite j;
    public Sprite k;
    public Sprite l;
    public Sprite m;
    public Sprite n;
    public Sprite o;
    public Sprite p;


    float timer = 1f;
    float delay = 0.2f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        firstScene();


    }
    // the start method is responsible for scaling the background images to the right size
    // the start method also reponsible for starting the infinit loop in the firstScene method.
    private void Start()
    {
        transform.localScale = new Vector3(0.9f , 0.76f, 1f);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = a;
    }

    // This method is responsible for looping trough all the sprite, with a 0.02sec delay
    void firstScene()
    {
        if (timer <= 0)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == a)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = b;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == b)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = c;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == c)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = d;
                timer = delay;
                return;

            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == d)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = e;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == e)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = f;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = g;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == g)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = h;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == h)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = a;
                timer = delay;
                return;
            }
        }
    }
}