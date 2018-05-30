using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Timer : MonoBehaviour {
    public static double deltaTime;
    public static double startTime = 60;
    double timer;
    public Text timerText;
       
    // Use this for initialization


        
       

        // Update is called once per frame
    void Update()
    {
        timeRunOut(60);
        timercounter();
    }
    void timercounter()
    {

        //  start time minus the time since level loaded 
        deltaTime = Time.timeSinceLevelLoad;
        timer = startTime - deltaTime;

        //  formatting minutes/seconds to string
        string minutes = ((int)timer / 60).ToString();
        string secounds = (timer % 60).ToString("f2");
        //  Setting current time to text
        timerText.text = minutes + ":" + secounds;

    }
        // if time exceeds gameOverTime it loads GameOver_Scene
        void timeRunOut(int gameOverTime)
        {

        if (deltaTime > gameOverTime)
            {
            ChainCollider.redPicked = false;
            BallScript.perkDropped = false;
            SceneManager.LoadScene("GameOver_Scene");
            }
        }
    }
