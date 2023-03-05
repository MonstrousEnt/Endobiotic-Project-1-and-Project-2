using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangerRootMaster : MonoBehaviour
{
	//Class Variables
	[Header("Roots")]
	public static GameMangerRootMaster instance;

	[Header("Game Mangers")]
	public SettingsGameManager settingsManager;
	public LevelResetManager levelManager;
	public PlayerManager playerManager;

	[Header("Unity Events Managers")]
	public UIManager uIEvents;


	private void Awake()
    {
       #region Singleton Reference
		//---Make sure there is only one instance of this class for each Scene.

		//If there is no instance of the object
		if (instance == null)
		{
			//Set an instance of it
			instance = this;
		}

		//Else, if there's already an instance
		else
		{
			//Destroy it
			Destroy(gameObject);
			return;
		}

		//This won't get destroy when you switch scene
		DontDestroyOnLoad(gameObject);
		#endregion
    }
}
