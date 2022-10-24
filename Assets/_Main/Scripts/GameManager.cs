using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _ordersToComplete = 3;
    
    [Header("GameOver screen")]
    [SerializeField]
    private GameObject _canvas;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private GameOverSO gameLostData;
    [SerializeField] private GameOverSO gameWonData;
    
    public static GameManager Instance { get; private set; }
    public bool IsGamePaused { get; private set; }
    public bool IsGameOver;

    public OrderController OrderController { get; private set; }
    
    private UIManager _uiManager;

    public delegate void GameOverHandler(bool hasWon);
    public static event GameOverHandler OnGameOver;
    public delegate void TruckArrivesHandler();
    public static event TruckArrivesHandler OnTruckArrives;
    public delegate void TruckLeavesHandler();
    public static event TruckLeavesHandler OnTruckLeaves;
    public delegate void ChangeSceneHandler();
    public static event ChangeSceneHandler OnChangedScene;
    
    private void Awake()
    {
        MakeSingleton();
        IsGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            InitGameOverScreen(true);
        }
    }

    private void Start()
    {
        OnGameOver += InitGameOverScreen;
        OnChangedScene += ResetValue;
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
        //DontDestroyOnLoad(gameObject);
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
        if(!gameOverScreen) return;
        if(!_canvas) return;
#if UNITY_EDITOR
        Debug.Log("Game Over");
#endif
        gameOverScreen.SetData(hasWon? gameWonData : gameLostData);
        Instantiate(gameOverScreen, _canvas.transform);
    }
    public void SetUIManager(UIManager uiManager) => _uiManager = uiManager;
    public void SetOrderController(OrderController orderController) => OrderController = orderController;

    private void ResetValue()
    {
        IsGameOver = false;
    }
    
    #region SceneManagement
    public IEnumerator ResetLevelAfter(float time)
    {
        yield return new WaitForSeconds(time);
        OnChangedScene?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetLevel()
    {
        OnChangedScene?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public IEnumerator LoadNextLevelAfter(float time)
    {
        yield return new WaitForSeconds(time);
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        OnChangedScene?.Invoke();
        SceneManager.LoadScene(currentScene + 1 > SceneManager.sceneCount + 1 ? currentScene : currentScene + 1, LoadSceneMode.Single);
    }
    #endregion
    
    
}
