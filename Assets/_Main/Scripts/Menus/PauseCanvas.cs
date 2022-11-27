using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(ResumeButtonOnClickHandler);
        mainMenuButton.onClick.AddListener(MainMenuButtonOnClickHandler);
    }

    private void ResumeButtonOnClickHandler()
    {
        GameManager.Instance.TogglePause();
    }

    private void MainMenuButtonOnClickHandler()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
