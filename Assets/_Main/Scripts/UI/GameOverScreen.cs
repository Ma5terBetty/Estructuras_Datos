using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private Image _background;
    [SerializeField] private GameOverSO screenData;
    [SerializeField] private TMP_Text[] texts;
    //[SerializeField] public Button[] buttons;

    private void Awake()
    {
        _background = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        SetBackgroundData(ref _background, screenData.Background);
        SetTextData(ref texts[0], screenData.Tittle);
        SetTextData(ref texts[1], screenData.Message);
        
        StartCoroutine(screenData.IsGameOver == true? ResetLevelAfter(5f) : LoadNextLevelAfter(5f));
    }

    private void SetTextData(ref TMP_Text text, in MyText textData)
    {
        text.text = textData.Text;
        text.font = textData.Font;
        text.color = textData.Color;
    }

    private void SetBackgroundData(ref Image background, in MyBackground textData)
    {
        background.sprite = textData.Image;
        background.color = textData.Color;
        background.material = textData.Material;
    }

    public void SetData(GameOverSO data) => screenData = data;

    private IEnumerator ResetLevelAfter(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private IEnumerator LoadNextLevelAfter(float time)
    {
        yield return new WaitForSeconds(time);
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1 > SceneManager.sceneCount + 1 ? currentScene : currentScene + 1);
    }

}
