using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Note: Feel free to add a loading screen.

public class LevelLoaderAsyncGameManager : MonoBehaviour
{
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    #region Level Loader Game Event
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