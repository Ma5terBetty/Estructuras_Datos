using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private bool _levelWon;
    private TMP_Text _continueText;
    private TMP_Text _mainMenuText;
    
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private Image background;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        _continueText = continueButton.GetComponentInChildren<TMP_Text>();
        _mainMenuText = mainMenuButton.GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        continueButton.onClick.AddListener(Continue);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(Continue);
        mainMenuButton.onClick.RemoveListener(MainMenu);
    }

    public void InitStats(bool levelWon)
    {
        _levelWon = levelWon;
        SetText(ref titleText, "Shift completed", "You are fired!!!", _levelWon);
        SetText(ref _continueText, _levelWon);
        SetText(ref _mainMenuText, _levelWon);
        background.color = levelWon ? new Color(0.3f, 0.3f, 0.3f, 0.5f) : new Color(0, 0, 0, 0.8f);
    }

    public void Continue()
    {
        if (_levelWon) GameManager.Instance.NextLevel();
        else GameManager.Instance.ResetLevel();
    }

    public void MainMenu()
    {
        GameManager.Instance.LoadLevel("MainMenu");
    }

    private void SetText(ref TMP_Text text, in string completedMessage, in string failedMessage, in bool levelWon)
    {
        text.text = levelWon ? completedMessage : failedMessage;
        text.color = levelWon ? Color.green : Color.red;
    }

    private void SetText(ref TMP_Text text, in bool levelWon)
    {
        text.color = levelWon ? Color.green : Color.red;
    }

}
