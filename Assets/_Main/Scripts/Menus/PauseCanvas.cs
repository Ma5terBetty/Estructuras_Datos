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
        GameManager.Instance.ToggleGamePause();

        if (GameManager.Instance.IsGamePaused)
            pauseCanvas.SetActive(true);
        else
            pauseCanvas.SetActive(false);

    }

    private void MainMenuButtonHandler()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
