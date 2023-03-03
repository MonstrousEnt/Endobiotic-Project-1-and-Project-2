using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Note: Feel free to add a loading screen.

public class LevelLoaderAsync : MonoBehaviour
{
    private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    private void Start()
    {
        GameMangerRootMaster.instance.levelManager.loadNextLevelUnityEvent.AddListener(loadNextScene);
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.levelManager.loadNextLevelUnityEvent.RemoveListener(loadNextScene);
    }

    /// <summary>
    /// Added the async operation to the list
    /// Afterwards Load or unload the scene
    /// </summary>
    /// <param name="nextScene"></param>
    private void loadNextScene(int nextScene)
    {
        scenesLoading.Add(SceneManager.LoadSceneAsync(nextScene));

        StartCoroutine(getScenceLoadProgress());
    }

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
}