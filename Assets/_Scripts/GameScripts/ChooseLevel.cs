using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour {
    public Text levelInputField;
	// Use this for initialization
	void Start () {
      

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Start_Scene");
        }
	}

    public void loadLevel(){
        if (levelInputField != null)
            GameManage.level = int.Parse(levelInputField.text);
            SceneManager.LoadScene("Main");
    }

}
