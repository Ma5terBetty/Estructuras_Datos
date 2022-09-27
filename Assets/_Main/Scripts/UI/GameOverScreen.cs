using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    private Image _background;
    [SerializeField] private GameOverSO screenData;
    [SerializeField] private TMP_Text[] texts;
    [SerializeField] public Button[] buttons;

    private void Awake()
    {
        _background = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        SetBackgroundData(ref _background, screenData.Background);
        SetTextData(ref texts[0], screenData.Tittle);
        SetTextData(ref texts[1], screenData.Message);
        SetTextData(ref texts[2], screenData.ButtonOne);
        SetTextData(ref texts[3], screenData.ButtonTwo);
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

}
