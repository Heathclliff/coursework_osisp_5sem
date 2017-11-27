using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	#region Variables

	public static GameManager instanse;

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
		if (instanse == null) 
		{
			instanse = this;
		} 
		else 
			if(instanse != this)
			{
				Destroy (gameObject);
			}
	}


	void Start()
	{
		GameObject prefab = Instantiate (prefabManager);
		prefab.transform.parent = this.gameObject.transform;
	}

	#endregion
}
