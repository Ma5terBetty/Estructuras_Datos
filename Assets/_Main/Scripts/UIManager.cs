using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    public static UIManager Instance;

    [SerializeField]
    GameObject bottomLayout;
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

    }

    void Start()
    {
        
    }

    
    void Update()
    {
    }

    public void AddItemsRequest()
    { 
        
    }
}
