using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameCanvas : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    { 
        Application.Quit();
    }
}
