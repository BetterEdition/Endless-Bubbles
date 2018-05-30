
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain: MonoBehaviour {
    // bullet speed is increasing y-value for chain
    public float bulletSpeed = 10;
    // IsFired keeps track of the state of the bullet
    public static bool IsFired;
    public Transform player;
    public AudioClip ShootSound;
    // Controls the behaviour of the bullet
    public bool perkpick;
    private float chainSize;

    // Use this for initialization
    void Start ()
    {
        
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = ShootSound;
    }
    
    void FixedUpdate()
    { 
        fireBullet();
        ChainHit();
    }

        // Controls when bullet is fired
        void fireBullet() {
        // Setting perkpicked to bool redPicked
        perkpick = ChainCollider.redPicked;
        //Checks if player clicked space
        if (IsFired) {
                if (GameManage.level < 50)
                {
                    chainSize = 7.5f;
                }
                else
                {
                    chainSize = 10;
                }
        
               // If perkpicked is false and localscale is over 7.5 set chain y value to 0
            if (!perkpick && transform.localScale.y >= chainSize)
            {
                transform.localScale = new Vector3(1f, 0f, 1f);
                // IsFired is turned false
                IsFired = false;
            }
            // If the perk is picked is true and y value is under 7.5 keep increasing y value
            if (perkpick)
            {
                if (transform.localScale.y <chainSize)
                {
                    // Scaling y value
                    transform.localScale = transform.localScale + Vector3.up * 0.050f;
                }

            }else
            {
                // Chain scale y if perk is not picked
                transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * 5 * bulletSpeed;
            }
        }

        else
        {
            // If fired == false set chain.position to position of player
            transform.position = player.position;
            // Scale y to 0 
            transform.localScale = new Vector3(1f, 0f, 1f);
        }

    }
   
    void ChainHit ()
    {
        // If Chaincollider collides and perkpick is true Isfired = true
        // If perkpick is false set IsFired = false
        if(ChainCollider.ChainCol){
            if (perkpick)
            {
                IsFired = true;
            }
            else
            {
                IsFired = false;
            }
            // If collide set y-value to 0
            bulletSpeed = 0;
            GetComponent<AudioSource>().Play();
            ChainCollider.ChainCol = false;
        }else{
            // keep increasing y-value for bullet
            bulletSpeed = 2;
        }
    }


}


