using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	#region Variables

	public static LevelManager Instanse;

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
		SoundManager.Instanse.PlayBackground ();
	}

	#endregion


	#region Public methods

	#endregion


	#region Private methods

	#endregion

}
