using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        resizecameraBasedonLv();

	}
    void resizecameraBasedonLv()
    {
        if (GameManage.level >= 50)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            gameObject.GetComponent<Camera>().orthographicSize = 12.5f;
        }
        if (GameManage.level < 50){
            transform.localScale = new Vector3(1f, 1f, 1f);
            gameObject.GetComponent<Camera>().orthographicSize = 8.5f;
        }
           


    }
}
