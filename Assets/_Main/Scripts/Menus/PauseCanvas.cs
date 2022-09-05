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
        if (_isGamePaused)
        {
            pauseCanvas.SetActive(false);
            _isGamePaused = false;
            Time.timeScale = 0;
        }
        else
        {
            pauseCanvas.SetActive(true);
            _isGamePaused = true;
            Time.timeScale = 1;
        }
    }

    private void MainMenuButtonHandler()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
