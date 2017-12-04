using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTabelPanel : MonoBehaviour {

    #region Variables

    const string COUNT_RESULTS = "results_count";
    const string CURRENT_RESULT = "current_result";

    [SerializeField] List<Text> textLabels;

    List<int> results;

    #endregion


    #region Properties

    int CountResults
    {
        get { return PlayerPrefs.GetInt(COUNT_RESULTS, 0); }
        set { PlayerPrefs.SetInt(COUNT_RESULTS, value); }
    }

    #endregion

    #region Unity lifecycle

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


    #region private Methods

    void ShowResultTable()
    {
        results = new List<int>();
        int currentResult;

        for (int i = 0; i < CountResults; i++)
        {
            currentResult = PlayerPrefs.GetInt(CURRENT_RESULT + i.ToString());
            results.Add(currentResult);
        }

        results.Add(GameManager.Instanse.score);
        results.Sort();

        if (results.Count > 5)
        {
            results.RemoveAt(5);
        }

        for (int i =0; i < results.Count; i++)
        {
            textLabels[i].text = i.ToString() + ". " + results[i];
        }
    }


    void SaveResults()
    {
        for (int i =0; i < results.Count; i++)
        {
            PlayerPrefs.SetInt(CURRENT_RESULT + i.ToString(), results[i]);
        }
    }

    #endregion

    #region Events handlers

    void GUIManager_OnGameScreen()
    {
        this.gameObject.SetActive (false);
        SaveResults();
    }


    void GUIManager_OnResultScreen()
    {
        this.gameObject.SetActive (true);
        ShowResultTable();
    }


    void GameManager_OnNewLevel()
    {
        this.gameObject.SetActive (false);
        SaveResults();
    }


    void GameManager_OnLevelEnd()
    {
        this.gameObject.SetActive (false);
    }

    #endregion
}
