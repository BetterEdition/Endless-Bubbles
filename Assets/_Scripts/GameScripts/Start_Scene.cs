using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Scene : MonoBehaviour {
    
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Start()
    {
        GameManage.level = 1;
    }
    public void startGame(){
        SceneManager.LoadScene("Main");
    }

    public  void creditScene(){
        SceneManager.LoadScene("Credit");
        
    }
    public void chooseLevel(){
        SceneManager.LoadScene("LevelScene");
    }

    public void goToStartScreen(){
        SceneManager.LoadScene("Start_Scene");
    }
}
