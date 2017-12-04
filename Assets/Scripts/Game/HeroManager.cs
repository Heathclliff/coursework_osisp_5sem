using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour 
{
	#region Variables

	public static HeroManager Instanse;

    [Header("Hero")]
    [SerializeField] GameObject heroPrefab;
    [SerializeField] Sprite staingHero;
    [SerializeField] Sprite movingHero;

    [Header("HeroParameters")]
    [SerializeField] float movingSpeed = 1f;
    [SerializeField] float fallingDownSpeed = 1f;
    [SerializeField] float heroLowPosition = 990f;

    GameObject hero;
    Vector2 heroPoisiton;

    bool isHeroMoving = false;
    bool isHeroFalling = false;

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


	void Start()
	{
        InitializeHero();
	}


    void Update()
    {
        if (isHeroMoving)
        {
            MoveHero(Vector2.zero);
        }

        if(isHeroFalling)
        {
            FallDownHero();
        }
    }

	#endregion


	#region Public methods

    public void MoveHero(Vector2 newPosition)
    {
        SetNewHeroPosition(newPosition);
    }

	#endregion


	#region Private methods

    void InitializeHero()
    {
        hero = Instantiate(heroPrefab);
        hero.transform.parent = this.gameObject.transform;
        heroPoisiton = hero.transform.position;
    }


    void SetNewHeroPosition(Vector2 newPosition)
    {
        heroPoisiton = newPosition;
    }


    void FallDownHero()
    {
        heroPoisiton = new Vector2(heroPoisiton.x, heroPoisiton.y - fallingDownSpeed);

        if (heroPoisiton.y < heroLowPosition)
        {
            GUIManager.Instanse.ShowResultScreen();
        }
    }


    void ChangeSprite(Sprite sprite)
    {
        SpriteRenderer currentSprite = hero.GetComponent<SpriteRenderer>();
        currentSprite.sprite = sprite;
    }

	#endregion


    #region Events handlers

    void GUIManager_OnGameScreen()
    {
        hero.SetActive(false);
    }


    void GUIManager_OnResultScreen()
    {
        hero.SetActive (false);
        isHeroMoving = false;
        isHeroFalling = false;
    }


    void GameManager_OnNewLevel()
    {
        hero.SetActive (true);
        isHeroMoving = false;
    }


    void GameManager_OnLevelEnd()
    {        
        hero.SetActive (false);
        isHeroMoving = false;
        isHeroFalling = false;
    }

    #endregion
}
