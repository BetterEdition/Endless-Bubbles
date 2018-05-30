
using UnityEngine;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{


    int levels;



    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        levels = GameManage.level;
        ChangeBackground();
        Debug.Log(levels);


    }

    void ChangeBackground()
    {
        if (levels < 7)
        {
            GetComponent<_level7Scene>().enabled = true;
            GetComponent<_level14Scene>().enabled = false;
            GetComponent<_level20Scene>().enabled = false;
            GetComponent<_level27Scene>().enabled = false;

        }
        if (levels >= 7 && levels < 14)
        {
            GetComponent<_level7Scene>().enabled = false;
            GetComponent<_level14Scene>().enabled = true;
            GetComponent<_level20Scene>().enabled = false;
            GetComponent<_level27Scene>().enabled = false;

        }
        if (levels >= 14 && levels < 20)
        {
            GetComponent<_level7Scene>().enabled = false;
            GetComponent<_level14Scene>().enabled = false;
            GetComponent<_level20Scene>().enabled = true;
            GetComponent<_level27Scene>().enabled = false;
        }
        if (levels >= 21)
        {
            GetComponent<_level7Scene>().enabled = false;
            GetComponent<_level14Scene>().enabled = false;
            GetComponent<_level20Scene>().enabled = false;
            GetComponent<_level27Scene>().enabled = true;
        }

    }
}
