using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public bool dontDestroyOnLoad;

    public static UIManager Instance;

    float testTimer = 0;

    //private GameObject UIOrder;
    //string localPath = "Assets/_Main/UI/Order.prefab"

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

        if (UIOrder() == null)
        {
            Debug.Log("La puta");
        }
        else
        {
            Debug.Log("Success");
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        testTimer += Time.deltaTime;

        if (testTimer > 3)
        { 
            var temp = Instantiate(UIOrder());
            temp.transform.SetParent(bottomLayout.transform);
            testTimer = 0;
        }
    }

    public void AddItemsRequest()
    { 
        
    }

    private GameObject UIOrder()
    { 
        return Resources.Load("Order", typeof(GameObject)) as GameObject;
    }
}
