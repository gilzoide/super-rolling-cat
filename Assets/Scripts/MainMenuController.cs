using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Score gameplayScore;
    public GameObject aboutPanel;

    public void StartFirstLevel()
    {
        gameplayScore.InitScore();
        SceneManager.LoadScene(1);
    }

    public void ToggleAbout()
    {
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }
}
