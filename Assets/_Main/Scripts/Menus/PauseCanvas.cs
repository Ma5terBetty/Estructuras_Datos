using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    //Temporal

    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    private bool _isGamePaused;

    private void Start()
    {
        resumeButton.onClick.AddListener(PauseGame);
        mainMenuButton.onClick.AddListener(MainMenuButtonHandler);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PauseGame();
    }

    private void PauseGame()
    {
        if (!GameManager.Instance.IsGamePaused)
        {
            GameManager.Instance.SetPause(true);
            pauseCanvas.SetActive(true);
        }
        else
        {
            GameManager.Instance.SetPause(false);
            pauseCanvas.SetActive(false);
        }

    }

    private void MainMenuButtonHandler()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        GameManager.Instance.SetPause(false);
    }
}
