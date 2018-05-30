using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winningScript : MonoBehaviour {

    public void ContinueGame()
    {
        GameManage.level = 28;
        SceneManager.LoadScene("Main");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }
}
