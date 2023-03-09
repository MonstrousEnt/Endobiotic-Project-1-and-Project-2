using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGameManager : MonoBehaviour
{
	[Header("Pause Data")]
	[SerializeField] private bool m_gameIsPause = false;

	[Header("FPS Data")]
	[SerializeField] private int m_lockFps = 60;
	[SerializeField] private int m_fps;

	#region Getters and Setters
	private void setFPS(int fps)
	{
		m_fps = Application.targetFrameRate = fps;
	}
	private void disableVsync()
	{
		QualitySettings.vSyncCount = 0;
	}
	#endregion

	#region Settings Game Events
	public void EnablePause()
	{
		m_gameIsPause = true;
		Time.timeScale = 0f;
	}
	public void DisablePause()
	{
		m_gameIsPause = false;
		Time.timeScale = 1f;
	}
	#endregion

	#region Unity Methods
	private void Start()
	{
		DisablePause();
		disableVsync();
		setFPS(m_lockFps);
	}
    #endregion

}
