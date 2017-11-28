using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	#region Variables

	public static GameManager Instanse;

	[SerializeField] GameObject prefabManager;

	#endregion


	#region Events

	public static System.Action OnGameLoad;
	public static System.Action OnGameStart;
	public static System.Action OnLevelEnd;
	public static System.Action OnGameRestart;

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


	void OnEnable()
	{
		GameObject prefab = Instantiate (prefabManager);
		prefab.transform.parent = this.gameObject.transform;

	}


	void Start()
	{
		if (OnGameStart != null)
		{
			OnGameStart ();
		}
	}

	#endregion


	#region Public methods

	#endregion


	#region Private methods

	#endregion
}
