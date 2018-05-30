using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollider : MonoBehaviour
{
    public static bool redPicked;
    public Sprite perk;
    public Sprite chain;
    public static bool ChainCol;


    private void Update()
    {
        pickPerk();
    }
    void OnTriggerEnter2D( )
    {
        ChainCol = true;

    }

    IEnumerator after7Seconds()
    {
        yield return new WaitForSeconds(5);
        redPicked = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = chain;
    }
    void pickPerk()
    {
        //Check collision name
        if (redPicked)
        {

            Debug.Log("redChain: Chaincollider");
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = perk;
            StartCoroutine("after7Seconds");
            return;



        }
    }
   

}
