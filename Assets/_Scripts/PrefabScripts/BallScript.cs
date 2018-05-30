using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public ScriptableLarge BallSize;

    public Vector2 startForce;
    public Rigidbody2D rb;
    public GameObject[] perks;
    public GameObject nextBall;
    public int levels = GameManage.level;

    public static bool perkDropped;
    private Vector2 vel;
    // Use this for initialization
    void Start()
    {
        // Initial push to Ball RigidBody
        rb.AddForce(startForce, ForceMode2D.Impulse);
        //Scale to the Scriptable object value attached
        transform.localScale = new Vector3(BallSize.Size, BallSize.Size, BallSize.Size);
    }


  
    

    void OnTriggerEnter2D(Collider2D col)
    {
        //Check collision name
        if (col.gameObject.tag == "Bullet")
        {
            Split();
        }
    }

    public void Split()
    {
        // 6,6 % chance for either perk to spawn
        var randNumber = Random.Range(1, 16);
        // If nextBall is not null
        if (nextBall != null)
        {
            // If the number i 1 and no perk is dropped
            if (randNumber == 1 && !perkDropped)
            {
                //Drop perk
                Instantiate(perks[0], rb.position, Quaternion.identity);
                perkDropped = true;
            }
            else if (randNumber == 15 && !perkDropped)
            {
                Instantiate(perks[1], rb.position, Quaternion.identity);
                perkDropped = true;
            }
            // If level is under 7 
            if(levels < 7){
                //Instatiate 2 balls
                GameObject ballL = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ballR = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ballL.GetComponent<BallScript>().startForce = new Vector2(3f, 5f);
                ballR.GetComponent<BallScript>().startForce = new Vector2(-3f, 5f);
            }
            if (levels >=7 && levels < 14)
            {
                // Instatiate 4 balls 
                GameObject ballL = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ballR = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);
                GameObject ballL2 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ballR2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ballL.GetComponent<BallScript>().startForce = new Vector2(3f, 5f);
                ballR.GetComponent<BallScript>().startForce = new Vector2(-3f, 5f);
                ballL2.GetComponent<BallScript>().startForce = new Vector2(5f, 5f);
                ballR2.GetComponent<BallScript>().startForce = new Vector2(-5f, 5f);
            
            }

            if (levels >= 14)
            {
                GameObject ballL = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ballR = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                GameObject ballL2 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ballR2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                GameObject ballL3 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ballR3 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ballL.GetComponent<BallScript>().startForce = new Vector2(3f, 5f);
                ballR.GetComponent<BallScript>().startForce = new Vector2(-3f, 5f);

                ballL2.GetComponent<BallScript>().startForce = new Vector2(5f, 5f);
                ballR2.GetComponent<BallScript>().startForce = new Vector2(-5f, 5f);

                ballL3.GetComponent<BallScript>().startForce = new Vector2(6f, 5f);
                ballR3.GetComponent<BallScript>().startForce = new Vector2(-6f, 5f);
            
            }



        }
        // Pop sound
        GetComponent<AudioSource>().Play();
        // Destroy original gameobject(ball)
        Destroy(gameObject);

    }
}
