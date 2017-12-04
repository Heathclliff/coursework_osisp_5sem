using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareTWButton : Button 
{
    #region Variables

    const string APPLICATION_LINK = "application link";
    const string TWITTER_ADRESS = "http://twitter.com/intent/tweet";
    const string TWITTER_NAME_PARAMETER = "Check the amazing game";
    const string TWITTER_DESCRIPTION_PARAMETER = "My score is ";

    #endregion


    #region Unity lifecycle

    public override void OnMouseUp ()
    {
        base.OnMouseUp ();

        PostTwitt();
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

    void PostTwitt()
    {
        Application.OpenURL(TWITTER_ADRESS + "?text=" + WWW.EscapeURL(TWITTER_NAME_PARAMETER + "\n"
            + TWITTER_DESCRIPTION_PARAMETER + GameManager.Instanse.score.ToString()+ "\n" 
            + APPLICATION_LINK
        ));
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
