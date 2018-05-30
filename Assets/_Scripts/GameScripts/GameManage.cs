
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class GameManage : MonoBehaviour
{
    // int to determine ball index of Balls array
    int ball;
    // level number
    public static int level = 0;
    // Array of varies ballprefabs
    public GameObject[] _balls;

 
        void Update()
    {
        // Back to level screen
            if (Input.GetKeyDown("escape"))
            {
                SceneManager.LoadScene("Start_Scene");
            }
            // What happens when Ball is null
            WonGame();
            // What happens when Player is null
            GameOver();
    }

    public void GameOver()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            ChainCollider.redPicked = false;
            BallScript.perkDropped = false;
           SceneManager.LoadScene("GameOver_Scene");
        }
    }
    public void WonGame()
    {
        if (GameObject.FindGameObjectWithTag("Ball") == null && level == 27)
        {
            SceneManager.LoadScene("WinningStory_Scene");
        }
        else if (GameObject.FindGameObjectWithTag("Ball") == null)
            {
            //Resetting static booleans for next level instance
            ChainCollider.redPicked = false;
            BallScript.perkDropped = false;
            //Increasing level upon winnning
            level++;
            //Loading a new Main scene
            SceneManager.LoadScene("Main");
            }
            
        }

 

    void instatiateLevel(int Lv){
        // Integer array list of number of balls
        int[] ballInstances = Enumerable.Range(1, Lv).ToArray();
        // level text follows current level
        Level_Script.levelText = level.ToString();
        // Looping through the number array
        foreach (int i in ballInstances)
        {
            //Instantiating ball with random tweek on SpawnPosition
            Instantiate(_balls[ball], new Vector2(Random.Range(-4, 14), Random.Range(5, 14)), Quaternion.identity);
        }
       

        }
    // Spawning number/size of balls based on level
    void ballsSpawned()
    {
        // > 7 spawn small(2) balls and initiate number of balls based on level number
        if (level < 7 && level > 0)
        {
            ball = 2;
            instatiateLevel(level);

        }
        // Reaches level 7 instatiate 1 medium(1) ball
        if (level >= 7 && level < 14)
        {
            ball = 1;
            instatiateLevel(level - 6);

        }
        if (level >= 14 && level < 21)
        {
            ball = 0;
            instatiateLevel(level - 13);

        }
        if (level >=  21)
        {
            ball = 0;
            instatiateLevel(level - 20);

        }
    }


    void Start()
    {
        ballsSpawned();
    }

    }
	
	

