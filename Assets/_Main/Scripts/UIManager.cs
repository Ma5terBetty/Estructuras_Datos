using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class UIManager : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    public static UIManager Instance;

    private Timer timer;

    [SerializeField]
    GameObject bottomLayout;

    [SerializeField]
    public GameObject NameShow;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (dontDestroyOnLoad)
            { 
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        { 
            Destroy(gameObject);
        }

        bottomLayout = transform.GetChild(0).gameObject;
        timer = GetComponentInChildren<Timer>();

    }

    void Start()
    {
        GameManager.Instance.SetUIManager();
    }

    public void ShowName(string name)
    { 
        NameShow.SetActive(true);
        NameShow.GetComponentInChildren<TMP_Text>().text = name;
    }

    public void TurnOffName()
    {
        NameShow.SetActive(false);
    }

    public void SetTimer(float time)
    {
        timer.SetInit(time);
    }
}
