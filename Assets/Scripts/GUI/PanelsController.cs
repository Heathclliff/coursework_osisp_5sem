using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsController : MonoBehaviour 
{
	#region Variables

	const string BestScoreKey = "BestScore";

	[SerializeField] GameObject LevelPanel;
	[SerializeField] GameObject ResultPanel;

	[SerializeField] Text currentScoreLabel;
	[SerializeField] Text bestScoreLabel;
	[SerializeField] Text resultScoreLabel;

	int bestScore;

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

		bestScore = PlayerPrefs.GetInt (BestScoreKey);
		bestScoreLabel.text = bestScore.ToString ();
	}


	void OnEnable()
	{

	}


	void OnDisable()
	{

	}

	#endregion

	#region Public methods

	public void SetScore(int score)
	{
		if (score > bestScore) 
		{
			bestScore = score;
			PlayerPrefs.SetInt (BestScoreKey,bestScore);
		}

		currentScoreLabel.text = score.ToString ();
	}

	#endregion
}
