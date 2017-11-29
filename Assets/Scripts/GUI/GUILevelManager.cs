using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILevelManager : MonoBehaviour 
{
	#region Variables

	public static GUILevelManager Instanse;

	[SerializeField] Transform UICameraPosition;

	[Header("GameMenu")]
	[SerializeField] GameObject playButtonPrefab;
	[SerializeField] GameObject musicButtonPrefab;

	[SerializeField] List<GameObject> backgroundsList;

	GameObject background;

	GameObject playButton;
	GameObject musicButton;
	SpriteRenderer currentSprite;


	#endregion


	#region Unity lifecycle

	void Awake()
	{
		if (Instanse == null) 
		{
			Instanse = this;
		} 
		else 
			if(Instanse != this)
			{
				Destroy (gameObject);
			}
	}


	void Start()
	{
		SetBackground ();
		SetMusicButton ();
		SetPlayButton ();
	}


	void OnEnable()
	{
		GUIManager.OnGameScreen += GUIManager_OnGameScreen;
		GUIManager.OnResultScreen += GUIManager_OnResultScreen;

		GameManager.OnNewLevel += GameManager_OnNewLevel;
		GameManager.OnLevelEnd += GameManager_OnLevelEnd;
	}


	void OnDisable()
	{
		GUIManager.OnGameScreen -= GUIManager_OnGameScreen;
		GUIManager.OnResultScreen -= GUIManager_OnResultScreen;

		GameManager.OnNewLevel -= GameManager_OnNewLevel;
		GameManager.OnLevelEnd -= GameManager_OnLevelEnd;
	}

	#endregion


	#region Public methods

	#endregion


	#region Private methods

	void SetMusicButton()
	{
		musicButton = Instantiate (musicButtonPrefab, UICameraPosition);
		musicButton.transform.parent = this.gameObject.transform;
	}

	void SetPlayButton()
	{
		playButton = Instantiate (playButtonPrefab, UICameraPosition);
		playButton.transform.parent = this.gameObject.transform;
	}


	void SetBackground()
	{
		int randomNumber = Random.Range (0,backgroundsList.Count);
		background = Instantiate (backgroundsList[randomNumber],UICameraPosition);
		background.transform.parent = this.gameObject.transform;

		currentSprite = background.GetComponent<SpriteRenderer> ();
		if (currentSprite != null) 
		{
			Vector2 currentSize = currentSprite.bounds.size;
			background.transform.localScale = new Vector2 (Screen.width / (currentSize.x * Camera.main.orthographicSize * Camera.main.orthographicSize), Screen.height / (currentSize.y * Camera.main.orthographicSize * Camera.main.orthographicSize ));
		} 
		else 
		{
			Debug.Log ("Cannot find SpriteRenderer for " + background.gameObject.name);
		}
	}


	#endregion


	#region Events handlers

	void GUIManager_OnGameScreen()
	{
		playButton.SetActive (true);
		musicButton.SetActive (true);
	}

	void GUIManager_OnResultScreen()
	{
		
	}


	void GameManager_OnNewLevel()
	{
		
	}


	void GameManager_OnLevelEnd()
	{
		
	}

	#endregion
}
