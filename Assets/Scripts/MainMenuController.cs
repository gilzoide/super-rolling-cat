using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public LevelInfo firstLevelInfo;
    public Score gameplayScore;
    public GameObject aboutPanel;

    public void StartFirstLevel()
    {
        gameplayScore.InitScore();
        SceneManager.LoadScene(firstLevelInfo.sceneName);
    }

    public void ToggleAbout()
    {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }
}
