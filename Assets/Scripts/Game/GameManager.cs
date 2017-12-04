using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	#region Variables

	public static GameManager Instanse;

	[SerializeField] GameObject prefabManager;
    [SerializeField] float movingSpeed = 1f;

	public int score = 0;

	#endregion


    #region Properties

    public float MovingSpeed
    {
        get { return movingSpeed; }
        set 
        {
            if (movingSpeed != value)
            {
                movingSpeed = value;
            }
        }
    }

    #endregion


	#region Events

	//public static System.Action OnGameStart;
	public static System.Action OnNewLevel;
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

	}


	void Start()
	{
		GameObject prefab = Instantiate (prefabManager);
		prefab.transform.parent = this.gameObject.transform;
	}

	#endregion


	#region Public methods

	public void PlayNewLevel()
	{
		if (OnNewLevel != null) 
		{
			OnNewLevel ();
		}
	}


	public void PlayLevelEnd()
	{
		if (OnLevelEnd != null) 
		{
			OnLevelEnd ();
		}
	}

	public void PlayGameRestart()
	{
		if (OnGameRestart != null) 
		{
			OnGameRestart ();
		}
	}

	#endregion


	#region Private methods

	#endregion
}
