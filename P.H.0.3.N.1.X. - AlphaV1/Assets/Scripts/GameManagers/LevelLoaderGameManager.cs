using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderGameManager : MonoBehaviour
{
	[SerializeField] private Animator m_animator; 

    private void Start()
    {
        GameMangerRootMaster.instance.levelManager.loadNextLevelUnityEvent.AddListener(LoadNextLevel);
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.levelManager.loadNextLevelUnityEvent.RemoveListener(LoadNextLevel);
    }

    /// <summary>
    /// Load the next scene.
    /// </summary>
    /// <param name="buildIndex"></param>
    private void LoadNextLevel(int buildIndex)
	{
        SceneManager.LoadScene(buildIndex);
    }
}
