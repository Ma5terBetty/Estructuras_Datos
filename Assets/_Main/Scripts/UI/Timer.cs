using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime;

    [Header("Timer")]
    [SerializeField] private float time = 200f;
    
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
        if (_currentTime < (time/4) && _currentTime > (time/7))
            ChangeTextColor(Color.yellow);
        else if (_currentTime < (time/7))
            ChangeTextColor(Color.red);
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
}
