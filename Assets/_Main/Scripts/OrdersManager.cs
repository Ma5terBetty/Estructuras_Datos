using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdersManager : MonoBehaviour
{
    public bool dontDestroyOnLoad;
    public static OrdersManager Instance;

    [SerializeField]
    GameObject rightUIPanel;
    [SerializeField]
    GameObject orderUIPrefab;

    public List<Order> currentOrders = new List<Order>();
    public List<Pallet> pallets = new List<Pallet>();
    Dictionary<Order, GameObject> ordersUI = new Dictionary<Order, GameObject>();

    float timer = 0f;

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
    }
    private void Start()
    {
        TestOrder();
    }
    void Update()
    {
        //timer += Time.deltaTime;
        if (timer > 60f)
        {
            GenerateOrder();
            timer = 0f;        
        }
    }
    public void DepartPallet(Pallet pallet, Order order)
    {
        for (int i = 0; i < pallets.Count; i++)
        {
            if (pallets[i] == pallet)
            {
                Destroy(pallets[i].gameObject);
                pallets.RemoveAt(i);
            }
        }
        for (int i = 0; i < currentOrders.Count; i++)
        {
            if (order == currentOrders[i])
            {
                Destroy(ordersUI[order]);
                //Destroy(currentOrders[i].gameObject);
                currentOrders.RemoveAt(i);
            }
        }

        Debug.Log("Order Completed");
    }

    void GenerateOrder()
    {
        int[] temp = new int[4];
        for (int i = 0; i < temp.Length; i++)
        { 
            temp[i] = Mathf.RoundToInt(Random.Range(0, 4));
        }
        Order orderData = new Order(temp[0], temp[1], temp[2], temp[3]);

        GameObject order = Instantiate(orderUIPrefab, rightUIPanel.transform);

        order.GetComponent<OrderUI>().data = orderData;
        order.GetComponent<OrderUI>().SetInfo();
        //order.transform.SetParent(rightUIPanel.transform);
        order.transform.localScale = Vector3.one;

        currentOrders.Add(orderData);
        ordersUI.Add(orderData, order);
    }

    void TestOrder()
    {
        Order orderData = new Order(1, 1, 1, 1);

        GameObject order = Instantiate(orderUIPrefab, rightUIPanel.transform);

        order.GetComponent<OrderUI>().data = orderData;
        order.GetComponent<OrderUI>().SetInfo();
        //order.transform.SetParent(rightUIPanel.transform);
        order.transform.localScale = Vector3.one;

        currentOrders.Add(orderData);
        ordersUI.Add(orderData, order);
    }
}
