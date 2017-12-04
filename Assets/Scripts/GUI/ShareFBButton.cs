using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareFBButton : Button 
{
    #region Variables

    const string FACEBOOK_ADRESS = "https://facebook.com/dialog/feed?";
    const string DESCRIPTION_PARAMETER = "Enjoy Fun, free games! Challenge yourself or share with friends. Fun and easy to use game ";
    const string APP_ID = "135927103";
    const string LINK = "https://google.com";
    const string PICTURE_LINK = "";
    const string CAPTION = "Check out my score: ";

    #endregion

    #region Unity lifecycle

    public override void OnMouseUp ()
    {
        base.OnMouseUp ();

        PostFacebook();
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


    #region Private methods

    void PostFacebook()
    {
        Debug.Log("facebook");
        Application.OpenURL(FACEBOOK_ADRESS + "app_id=" + APP_ID + "&link=" + LINK + "&picture=" + PICTURE_LINK
            + "&caption=" + CAPTION + GameManager.Instanse.score.ToString() + "&description" + DESCRIPTION_PARAMETER);
    }

    #endregion


    #region Events handlers

    void GUIManager_OnGameScreen()
    {
        this.gameObject.SetActive (false);
    }


    void GUIManager_OnResultScreen()
    {
        this.gameObject.SetActive (false);
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
