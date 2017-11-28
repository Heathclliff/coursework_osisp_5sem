using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
	#region Variables

	public static SoundManager Instanse;

	[Header("Sounds")]
	[SerializeField] AudioSource click;
	[SerializeField] AudioSource background;
	[SerializeField] AudioSource loose;

	#endregion


	#region Properties

	public bool IsMusicEnable
	{
		get { return Convert.ToBoolean(PlayerPrefs.GetInt("music",1)); }
		set { 
			if (value) 
			{
				PlayerPrefs.SetInt ("music",1);
				background.Play ();
			}
			else 
			{
				PlayerPrefs.SetInt ("music",0);
				background.Stop ();
			}
		}
	}

	#endregion

	#region Unity lifecycle

	void Awake()
	{
		if (Instanse == null) 
		{
			Instanse = this;
		} 
		else
		{
			if (Instanse != this) 
			{
				Destroy (gameObject);
			}
		}
	}


	void OnEnable()
	{
		GameManager.OnGameStart += GameManager_OnGameStart;
		GameManager.OnLevelEnd += GameManager_OnLevelEnd;
	}


	void OnDisable()
	{
		GameManager.OnGameStart -= GameManager_OnGameStart;
		GameManager.OnLevelEnd -= GameManager_OnLevelEnd;
	}


	void Start()
	{
		InitializeSounds ();
		//PlayBackground ();
	}

	#endregion


	#region Public methods

	public void PlayClick()
	{
		if (IsMusicEnable) 
		{
			click.Play ();
		}
	}


	public void PlayLoose()
	{
		if (IsMusicEnable) 
		{
			loose.Play ();
		}
	}


	public void PlayBackground()
	{
		if (IsMusicEnable) 
		{
			background.Play ();
		}
	}

	#endregion


	#region Events handlers

	void GameManager_OnGameStart()
	{
		
	}


	void GameManager_OnLevelEnd()
	{
		PlayLoose ();
	}

	#endregion


	#region Private methods

	void InitializeSounds()
	{
		click = (AudioSource) Instantiate (click);
		background = (AudioSource) Instantiate (background);
		loose = (AudioSource) Instantiate (loose);

		click.transform.parent = this.gameObject.transform;
		background.transform.parent = this.gameObject.transform;
		loose.transform.parent = this.gameObject.transform;
	}

	#endregion
}
