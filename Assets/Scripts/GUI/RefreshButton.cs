using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshButton : Button 
{
    #region Unity lifecycle

    public override void OnMouseUp ()
    {
        base.OnMouseUp ();

        GUIManager.Instanse.ShowGameScreen ();
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
