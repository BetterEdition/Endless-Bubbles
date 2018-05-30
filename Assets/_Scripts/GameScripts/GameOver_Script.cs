using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_Script : MonoBehaviour
{
    public GameObject btnQuit;
    public GameObject btnContinue;

    private void Start()
    {
        AdManager.Instance.ShowVideo();

    }

    void Update()
    {
        
    }


    public void quitClick(){
        GameManage.level = 1;
        SceneManager.LoadScene("Start_Scene");
    }
    public void continueClick(){
      
        SceneManager.LoadScene("Main");
    }
}
