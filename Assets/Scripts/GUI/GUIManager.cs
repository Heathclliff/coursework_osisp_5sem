using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour 
{
	#region Variables

	public static GUIManager Instanse;

	#endregion

	#region Events

	public static System.Action OnResultScreen;
	public static System.Action OnGameScreen;

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

	}

	#endregion


	#region Public methods

	public void ShowResultScreen()
	{
		if (OnResultScreen != null) 
		{
			OnResultScreen ();
		}
	}

	#endregion


	#region Private methods

	#endregion
}
