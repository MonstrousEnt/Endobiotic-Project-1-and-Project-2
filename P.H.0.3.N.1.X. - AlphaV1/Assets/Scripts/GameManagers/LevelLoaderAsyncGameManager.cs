using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: Match 12, 2023
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
    /// <summary>
    /// Added the async operation to the list
    /// Afterwards Load or unload the scene
    /// </summary>
    /// <param name="levelData"></param>
    public void LoadNextScene(LevelDataScriptableObject levelData)
    {
        scenesLoading.Add(SceneManager.LoadSceneAsync(levelData.buildindex));

        StartCoroutine(getScenceLoadProgress());
    }
    #endregion

    #region Private Level Load Methods
    /// <summary>
    /// Unload the current scene async and load the next scene async once it has finished loading.
    /// </summary>
    private IEnumerator getScenceLoadProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            //When the game hasn't finished loading
            while (!scenesLoading[i].isDone)
            {
                //Next frame
                yield return null;
            }
        }
    }
    #endregion
}