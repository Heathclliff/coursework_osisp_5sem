using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILevelManager : MonoBehaviour 
{
	#region Variables

	public static GUILevelManager Instanse;

	[SerializeField] Transform UICameraPosition;
	[SerializeField] List<GameObject> backgroundsList;

	GameObject background;
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
		int randomNumber = Random.Range (0,backgroundsList.Count);
		background =Instantiate (backgroundsList[randomNumber],UICameraPosition);
		background.transform.parent = this.gameObject.transform;

		SetBackgroundSizes ();
	}


	void OnEnable()
	{
		GameManager.OnGameStart += GameManager_OnGameStart;
	}


	void OnDisable()
	{
		GameManager.OnGameStart -= GameManager_OnGameStart;
	}

	#endregion


	#region Public methods

	#endregion


	#region Private methods

	void SetBackgroundSizes()
	{
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

	void GameManager_OnGameStart()
	{
		
	}

	#endregion
}
