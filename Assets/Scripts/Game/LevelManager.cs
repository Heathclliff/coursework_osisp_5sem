using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	#region Variables

	public static LevelManager Instanse;

    [SerializeField] int heightkoeff;
    [SerializeField] int widthKoeff;
    [SerializeField] Color32 blockColor;

    [SerializeField] GameObject blockPrefab;
    List<GameObject> blocks;

    bool isBlocksMoving = false;

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
        InitializeBlocksPool();
	}


    void Update()
    {
        if (isBlocksMoving)
        {
            MoveBlocks();
        }
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

    void InitializeBlocksPool()
    {
        blocks = new List <GameObject>();
        SpriteRenderer blockSprite;

        for (int i = 0; i < 3; i++)
        {
            blocks[i] = Instantiate(blockPrefab);
            blocks[i].transform.parent = this.gameObject.transform;
            ScaleBlock(blocks[i]);
            blockSprite = blocks[i].GetComponent<SpriteRenderer>();
            blockSprite.color = blockColor;
        }

        SetNewBlockPosition(blocks[0]);
    }


    void SetNewBlockPosition(GameObject block)
    {

    }


    void ScaleBlock(GameObject block)
    {
        block.transform.localScale = new Vector2(Screen.height/heightkoeff, Screen.width/ widthKoeff);
    }


    void MoveBlocks()
    {
        Vector2 blockPoisiton;
        for (int i = 0; i < blocks.Count; i++)
        {
            blockPoisiton = blocks[i].transform.position;
            blockPoisiton = new Vector2(blockPoisiton.x - GameManager.Instanse.MovingSpeed, blockPoisiton.y);
        }
    }

	#endregion


    #region Events handlers

    void GUIManager_OnGameScreen()
    {
        this.gameObject.SetActive (false);
    }


    void GUIManager_OnResultScreen()
    {
        this.gameObject.SetActive (true);
    }


    void GameManager_OnNewLevel()
    {
        this.gameObject.SetActive (false);
    }


    void GameManager_OnLevelEnd()
    {        
        this.gameObject.SetActive (true);
    }

    #endregion

}
