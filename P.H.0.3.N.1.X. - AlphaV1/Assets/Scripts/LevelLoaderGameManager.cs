using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderGameManager : MonoBehaviour
{
	//Class Variables
	[SerializeField] private Animator _animator; 
	[SerializeField] private float _transtionTime = 1f;

    private void Awake()
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
    /// <param name="sceneName"></param>
    private void LoadNextLevel(LevelName scene)
	{
		//StopCoroutine(LoadLevel(scene.ToString()));
		StartCoroutine(LoadLevel(scene.ToString()));
	}

	/// <summary>
	/// Load the next scene, and run the cross fade transition before the next level load.
	/// </summary>
	/// <param name="sceneName"></param>
	/// <returns></returns>
	private IEnumerator LoadLevel(string sceneName)
	{
        //Play the transition
        _animator.SetTrigger("StartCrossfade");
		Debug.Log("Triggering crossfade!");

        //Wait for a couple seconds
        yield return new WaitForSeconds(_transtionTime);

        //Load the next scene
        SceneManager.LoadScene(sceneName);
	}

}
