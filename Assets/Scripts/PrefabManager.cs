using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour 
{
	#region Variables

	public static PrefabManager instanse;

	[SerializeField] List<GameObject> managers;
	[SerializeField] List<GameObject> loadedManagers;

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
		for (int i = 0; i < managers.Count; i++) 
		{
			loadedManagers.Add (Instantiate(managers[i]));
			loadedManagers [i].transform.parent = this.gameObject.transform;
		}
	}

	#endregion
}
