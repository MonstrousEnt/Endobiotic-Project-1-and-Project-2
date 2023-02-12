using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //open level one
            GameMangerRootMaster.instance.levelLoader.LoadNextLevel(LevelName.MainLevel);
        }
    }
}
