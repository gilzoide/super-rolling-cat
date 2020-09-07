using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Score gameplayScore;
    public GameObject title;
    public GameObject aboutPanel;

    void Start()
    {
        MusicController.PlayMenuTheme();
    }

    public void StartFirstLevel()
    {
        gameplayScore.InitScore();
        SceneManager.LoadScene(1);
    }

    public void ToggleAbout()
    {
        title.SetActive(!title.activeSelf);
        aboutPanel.SetActive(!aboutPanel.activeSelf);
    }
}
