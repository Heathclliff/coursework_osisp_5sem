using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsController : MonoBehaviour 
{
	#region Variables

	const string BestScoreKey 	= "BestScore";
	const string CherryCountKey = "CherryCount";

	[SerializeField] GameObject LevelPanel;
	[SerializeField] GameObject ResultPanel;
	[SerializeField] GameObject CheeryPanel;

	[SerializeField] Text currentScoreLabel;
	[SerializeField] Text bestScoreLabel;
	[SerializeField] Text resultScoreLabel;
	[SerializeField] Text cherryScoreLabel;

	[SerializeField] Text adviseTextLabel;

	int score = 0;
	int bestScore = 0;
	int cherryCount = 0;

	public static PanelsController  Instanse;

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


	void Start () 
	{
		LevelPanel.SetActive (false);
		ResultPanel.SetActive (false);
		adviseTextLabel.gameObject.SetActive (false);

		bestScore = PlayerPrefs.GetInt (BestScoreKey, 0);
		bestScoreLabel.text = bestScore.ToString ();

		cherryCount = PlayerPrefs.GetInt (CherryCountKey, 0);
		cherryScoreLabel.text = cherryCount.ToString ();

		currentScoreLabel.text = score.ToString ();
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

	public void IncreaseScore()
	{
		score++;

		adviseTextLabel.gameObject.SetActive (false);

		if (score > bestScore) 
		{
			bestScore = score;
			PlayerPrefs.SetInt (BestScoreKey, bestScore);
		}

		currentScoreLabel.text = score.ToString ();
	}


	public void IncreaseCheeryCount()
	{
		cherryCount++;
		PlayerPrefs.SetInt (CherryCountKey, cherryCount);
		cherryScoreLabel.text = cherryCount.ToString ();
	}

	#endregion


	#region Private methods

	void SetPanelsState(bool isLevelPanelActive, bool isResultPanelActive, bool isCherryPanelActive)
	{
		LevelPanel.SetActive (isLevelPanelActive);
		ResultPanel.SetActive (isResultPanelActive);
		CheeryPanel.SetActive (isCherryPanelActive);
	}

	#endregion


	#region Event handlers

	void GUIManager_OnGameScreen()
	{
		SetPanelsState (false, false, false);
        adviseTextLabel.gameObject.SetActive(false);
	}

	void GUIManager_OnResultScreen()
	{
		//SetPanelsState (false, true, false);
        //adviseTextLabel.gameObject.SetActive(false);
	}


	void GameManager_OnNewLevel()
	{
		SetPanelsState (true, false, true);
		adviseTextLabel.gameObject.SetActive (true);
	}


	void GameManager_OnLevelEnd()
	{
		SetPanelsState (false, true, false);
        adviseTextLabel.gameObject.SetActive(false);
	}

	#endregion
}
