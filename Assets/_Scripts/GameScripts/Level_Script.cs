using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Script : MonoBehaviour {
    public Text levelTxt;

    public static string levelText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(levelText == null){
            levelTxt.text = "Level: 1";
        }
        else{
            levelTxt.text = "Level: " + levelText;

        }
	}
}
