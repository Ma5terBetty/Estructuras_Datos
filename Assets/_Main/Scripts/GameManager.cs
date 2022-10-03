using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _ordersToComplete = 3;
    
    [Header("GameOver screen")]
    private GameObject _canvas;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private GameOverSO gameLostData;
    [SerializeField] private GameOverSO gameWonData;
    
    public static GameManager Instance { get; private set; }
    public bool IsGamePaused { get; private set; }
    public bool IsGameOver { get; private set; }

    public OrderController OrderController { get; private set; }
    
    private UIManager _uiManager;
    
    //[Header("Truck")]
    //public GameObject truck;

    public delegate void GameOverHandler(bool hasWon);
    public static event GameOverHandler OnGameOver;

    public delegate void TruckArrivesHandler();
    public static event TruckArrivesHandler OnTruckArrives;

    public delegate void TruckLeavesHandler();
    public static event TruckLeavesHandler OnTruckLeaves;
    
    private void Awake()
    {
        MakeSingleton();
        IsGameOver = false;
        //SetUIManager();
    }

    private void Start()
    {
        OnGameOver += InitGameOverScreen;
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

    public void GameOver(bool hasWon)
    {
        IsGameOver = true;
        OnGameOver?.Invoke(hasWon);
        if (hasWon == true)
        {
#if UNITY_EDITOR
            Debug.Log("Has won");
#endif
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Has lost");
#endif
        }
    }

    public void OrderCompleted()
    {
        _ordersToComplete--;
        if (_ordersToComplete == 0)
        {
            GameOver(true);
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

    private void InitGameOverScreen(bool hasWon)
    {
        gameOverScreen.SetData(hasWon? gameWonData : gameLostData);
        Instantiate(gameOverScreen, _canvas.transform);
    }
    
    public void SetUIManager() => _canvas = UIManager.Instance.gameObject;

    public void SetOrderController(OrderController orderController) => OrderController = orderController;
}
