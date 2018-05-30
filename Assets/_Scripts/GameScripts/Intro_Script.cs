using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("loadStart", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void loadStart(){
        SceneManager.LoadScene("Start_Scene");  
    }
}
