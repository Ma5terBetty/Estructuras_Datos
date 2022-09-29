using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameOverSO gameLostData;
    [SerializeField] private GameOverSO gameWonData;
    
    public static GameManager Instance { get; private set; }
    public bool IsGamePaused { get; private set; }

    public delegate void VictoryHandler();
    public static event VictoryHandler OnVictory;

    public delegate void DefeatHandler();
    public static event DefeatHandler OnDefeat;

    public delegate void TruckArrivesHandler();
    public static event TruckArrivesHandler OnTruckArrives;

    public delegate void TruckLeavesHandler();
    public static event TruckLeavesHandler OnTruckLeaves;
    public bool IsGameOver { get; private set; }

    public OrderController OrderController;
    public UIManager UIManager;

    public GameObject Truck;

    int _ordersToComplete = 3;

    private void Awake()
    {
        MakeSingleton();
        IsGameOver = false;
    }

    private void MakeSingleton()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetPause(bool isPause)
    {
        IsGamePaused = isPause;
        Time.timeScale = IsGamePaused ? 0 : 1;
    }

    public void GenerateNewOrder()
    { 
        OrderController.GenerateOrder();
    }

    public void GameOver()
    {
        OnDefeat?.Invoke();
        IsGameOver = true;
    }

    public void LevelSucceded()
    { 
        OnVictory?.Invoke();
        IsGameOver = true;
    }

    public void OrderCompleted()
    {
        _ordersToComplete--;
        if (_ordersToComplete == 0)
        {
            LevelSucceded();
        }
        else
        {
            TruckLeaves();
        }
    }

    public void TruckArrived()
    { 
        OnTruckArrives?.Invoke();
    }

    public void TruckLeaves()
    { 
        OnTruckLeaves?.Invoke();
    }
}
