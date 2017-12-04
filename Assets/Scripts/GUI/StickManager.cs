using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour 
{
    #region Variables

    public static StickManager Instanse;

    [SerializeField] GameObject stickPrefab;
    [SerializeField] float stickIncreasingCoeff;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] float rotationSpeed;

    GameObject stick;
    Transform stickTransfrom;

    bool isClicking = false;
    bool isRotating = false;

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
        InitializeStick();
    }


    void Update()
    {
        if (isClicking)
        {
            stickTransfrom.localScale = new Vector2(stickTransfrom.localScale.x, stickTransfrom.localScale.y + stickIncreasingCoeff);
        }

        if (isRotating)
        {
            RotateStick();
        }
    }


    void OnDown()
    {
        isClicking = true;
    }


    void OnUp()
    {
        isClicking = false;
        boxCollider.enabled = false;
    }

    #endregion


    #region Public methods

    public void SetStickPositionAndScale(GameObject hero)
    {
        stickTransfrom.localScale = new Vector2(stickTransfrom.localScale.x, 0);
    }

    #endregion


    #region Private methods

    void InitializeStick()
    {
        stick = Instantiate(stickPrefab);
        stick.transform.parent = this.gameObject.transform;
        stickTransfrom = stick.transform;
    }


    void RotateStick()
    {

    }

    #endregion


    #region Events handlers

    void GUIManager_OnGameScreen()
    {
        stick.SetActive(false);
    }


    void GUIManager_OnResultScreen()
    {
        stick.SetActive (false);
    }


    void GameManager_OnNewLevel()
    {
        stick.SetActive (true);
        boxCollider.enabled = true;
        isClicking = false;
        isRotating = false;
    }


    void GameManager_OnLevelEnd()
    {        
        stick.SetActive (false);
    }

    #endregion
}
