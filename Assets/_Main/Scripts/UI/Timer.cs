using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime;

    [Header("Timer")]
    [SerializeField] private float _time = 200f;
    [SerializeField] private float yellowPercentage = 40f;
    [SerializeField] private float redPercentage = 20f;

    bool isRunning;
    
    [Header("UI elements")]
    [SerializeField] private TMP_Text timeText;

    public Action OnTimeEnded { get; private set; }

    private void Start()
    {
        _currentTime = _time;

        GameManager.OnDefeat += StopTimer;
        GameManager.OnVictory += StopTimer;
    }

    private void Update()
    {
        //ToDo: crear un bool en el gameManager isGameOver, posible error de ejecutarce el evento de ontimeended multiples veces

        if (isRunning)
        {
            DecreaseTimer();
            DisplayTime();
            if (_currentTime < PercentageOf(_time, yellowPercentage) && _currentTime > PercentageOf(_time, redPercentage))
                ChangeTextColor(Color.yellow);
            else if (_currentTime < PercentageOf(_time, redPercentage))
                ChangeTextColor(Color.red);
            else
                ChangeTextColor(Color.white);
        }
    }

    private void DecreaseTimer()
    {
        if (_currentTime < 0.1f)
        {
            _currentTime = 0;
            OnTimeEnded?.Invoke();
            GameManager.Instance.OrderController.CheckForOrder(true);
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

    public void SetInit(float time)
    { 
        _time = time;
        _currentTime = _time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;

        Debug.Log("ZAWARUDO TOKIO TOMARE");
    }
}
