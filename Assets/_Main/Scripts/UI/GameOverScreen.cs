using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameOverSO screenData;
    private Image _background;
    public TMP_Text[] _texts;

    private void Awake()
    {
        _background = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        SetBackgroundData(ref _background, screenData.Background);
        SetTextData(ref _texts[0], screenData.Tittle);
        SetTextData(ref _texts[1], screenData.Message);
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
