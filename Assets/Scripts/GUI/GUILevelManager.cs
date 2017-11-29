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
	[SerializeField] GameObject cherryPrefab;

	[Header("ResultScreen")]
	[SerializeField] GameObject homeButtonPrefab;
	[SerializeField] List<GameObject> backgroundsList;

	GameObject background;

	GameObject playButton;
	GameObject musicButton;
	GameObject cherry;
	SpriteRenderer currentSprite;

	GameObject homeButton;

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
		SetCherry ();
		SetHomeButton ();
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


	void SetCherry()
	{
		cherry = Instantiate (cherryPrefab);
		cherry.transform.parent = this.gameObject.transform;
		cherry.SetActive (false);
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


	void SetHomeButton()
	{
		homeButton = Instantiate (homeButtonPrefab);
		homeButton.transform.parent = this.gameObject.transform;
		homeButton.SetActive (false);
	}

	#endregion


	#region Events handlers

	void GUIManager_OnGameScreen()
	{
		playButton.SetActive (true);
		musicButton.SetActive (true);
		cherry.SetActive (false);
	}

	void GUIManager_OnResultScreen()
	{
		cherry.SetActive (false);
		homeButton.SetActive (false);
	}


	void GameManager_OnNewLevel()
	{
		playButton.SetActive (false);
		musicButton.SetActive (false);
		cherry.SetActive (true);
	}


	void GameManager_OnLevelEnd()
	{
		cherry.SetActive (false);
		homeButton.SetActive (false);
	}

	#endregion
}
