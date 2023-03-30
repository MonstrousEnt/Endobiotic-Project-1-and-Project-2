using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the game manager class for level loader async.
 * Notes: Feel free to add a loading screen.
 * Resources: 
 *	Designing a Loading Screen in Unity:https://youtu.be/iXWFTgFNRdM
 *	How to make a LOADING BAR in Unity: https://youtu.be/YMj2qPq9CP8
 */

public class LevelLoaderAsyncGameManager : MonoBehaviour
{
    #region Class Variables 
    //Async Operation
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    #endregion

    #region Level Loader Game Events
    public void LoadNextScene(LevelDataScriptableObject levelData)
    {
        scenesLoading.Add(SceneManager.LoadSceneAsync(levelData.buildindex));

        StartCoroutine(getScenceLoadProgress());
    }
    #endregion

    #region Level Load Methods
    private IEnumerator getScenceLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
    }
    #endregion
}