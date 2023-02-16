using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGameManager : MonoBehaviour
{
	[SerializeField] private int fps;
	[SerializeField] bool gameIsPause = false;

	private void Start()
	{
		//Unpause the game
		ActivePause(false, 1f);

		//Locks FPS to 60.
		FPSLock();
	}

	private void FPSLock()
	{
		//Disable vSync.
		QualitySettings.vSyncCount = 0;

		//Setting application frame rate.
		Application.targetFrameRate = fps;
	}

	public void ActivePause(bool flag, float timeScale)
	{
		gameIsPause = flag;
		Time.timeScale = timeScale;
	}
}
