using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameCanvas : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private string sceneName;

    private void Start()
    {
        startGame.onClick.AddListener(StartGameScene);
    }

    private void StartGameScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}
