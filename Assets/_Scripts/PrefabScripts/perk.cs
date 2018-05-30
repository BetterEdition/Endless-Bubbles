using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perk : MonoBehaviour
{
    // Array
    private List<Vector2> vels = new List<Vector2>();
    private List<GameObject> balls = new List<GameObject>();
    // Update is called once per frame

    //Destroy the perk if it is still active after 5 seconds
    IEnumerator VanishingAfter5()
    {
        yield return new WaitForSeconds(5);
        if (gameObject.activeSelf)
        {
           Destroy(gameObject);
        }
        
    }
    // Loops through the balls and if the ball is null do nothing, but if it is something remove constraints
    // And set velocity
    // After unfreezing destroy the perk
    void UnFreeze()
    {
        Debug.Log("I reach here unfreeze?");
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i] != null)
            {
                balls[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                balls[i].GetComponent<Rigidbody2D>().velocity = vels[i];
            }
        }
        Destroy(gameObject);


    }
    // If perk collide with tag "Player"
    // then if the perk game tag is *specific perk*
    // Do something
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (gameObject.tag == "redChain")
            {
                //Sets the bool redPicked to true
                Debug.Log("redChain: Player");
                ChainCollider.redPicked = true;
            }

            if (gameObject.tag == "Freeze")
            {
                // Adds all ball objects to a ball list
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("Ball").Length; i++)
                {
                    balls.Add(GameObject.FindGameObjectsWithTag("Ball")[i]);
                }
                // Go through ball list
                foreach (var ball in balls)
                {
                    // Add the current balls velocity to the Vector2 list
                    vels.Add(ball.GetComponent<Rigidbody2D>().velocity);
                    // Freezing all constraints
                    ball.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    Debug.Log("I reach freezing point");
                }
                // After that, Invoke "UnFreeze" after 5 seconds
                Debug.Log("I atleast invoke?");
                Invoke("UnFreeze", 5.0f);
            }
            // Set gameObject to false to maintain runtime on script
            gameObject.SetActive(false);
        }

    }

    

    void Start ()
	{
	    StartCoroutine("VanishingAfter5");
	}
}
