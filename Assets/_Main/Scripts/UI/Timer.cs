using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime;

    [Header("Timer")]
    [SerializeField] private float time = 200f;
    [SerializeField] private float yellowPercentage = 40f;
    [SerializeField] private float redPercentage = 20f;
    
    [Header("UI elements")]
    [SerializeField] private TMP_Text timeText;

    public Action OnTimeEnded { get; private set; }

    private void Start()
    {
        _currentTime = time;
    }

    private void Update()
    {
        DecreaseTimer();
        DisplayTime();
        if (_currentTime < PercentageOf(time, yellowPercentage) && _currentTime > PercentageOf(time, redPercentage))
            ChangeTextColor(Color.yellow);
        else if (_currentTime < PercentageOf(time, redPercentage))
            ChangeTextColor(Color.red);
        else
            ChangeTextColor(Color.white);
    }

    private void DecreaseTimer()
    {
        if (_currentTime < 0.1f)
        {
            _currentTime = 0;
            OnTimeEnded?.Invoke();
            return;
        }
        _currentTime -= Time.deltaTime;
    }
    
    private void DisplayTime()
    {
        var minutes = Mathf.FloorToInt(_currentTime / 60);
        var seconds = Mathf.FloorToInt(_currentTime % 60);

        timeText.text = $"{minutes:00}:{seconds:00}";
    }

    private void ChangeTextColor(in Color color) => timeText.color = color;

    private float PercentageOf(in float x, in float percentage) => x * (percentage / 100);
}
