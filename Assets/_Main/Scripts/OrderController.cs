using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    [SerializeField]
    GameObject palletObject;
    [SerializeField]
    GameObject rightUIPanel;
    [SerializeField]
    GameObject orderUIPrefab;

    Order palletOrder;
    Order currentOrder;
    Dictionary<Order, GameObject> ordersUI = new Dictionary<Order, GameObject>();
    //float timer = 0f;
    //float orderTime;

    private void Start()
    {
        GameManager.Instance.orderController = this;
        
        currentOrder = new Order();
        palletOrder = palletObject.GetComponentInChildren<Pallet>().currentOrder;
        palletObject.SetActive(false);

    }
    void Update()
    {
        
    }

    public void CheckForOrder(bool isTimeOver = false)
    {
        if (isTimeOver)
        {
            if (currentOrder.redAmount == palletOrder.redAmount
            && currentOrder.greenAmount == palletOrder.greenAmount
            && currentOrder.blueAmount == palletOrder.blueAmount
            && currentOrder.yellowAmount == palletOrder.yellowAmount)
            {
                GameManager.Instance.OrderCompleted();
                GameManager.Instance.TruckLeaves();
            }
            else
            {
                GameManager.Instance.GameOver(false);
            }
        }
        else
        {
            if (currentOrder.redAmount == palletOrder.redAmount
            && currentOrder.greenAmount == palletOrder.greenAmount
            && currentOrder.blueAmount == palletOrder.blueAmount
            && currentOrder.yellowAmount == palletOrder.yellowAmount)
            {
                Debug.Log("Se termina");
                GameManager.Instance.OrderCompleted();
                GameManager.Instance.TruckLeaves();
            }
        }
    }

    /*public void GenerateOrder()
    {
        palletObject.SetActive(true);
        orderTime = 0;

        int[] temp = new int[4];
        for (int i = 0; i < temp.Length; i++)
        { 
            temp[i] = Mathf.RoundToInt(Random.Range(0, 4));
            orderTime += temp[i];
        }
        Order orderData = new Order(temp[0], temp[1], temp[2], temp[3]);

        currentOrder = orderData;

        GameObject order = Instantiate(orderUIPrefab, rightUIPanel.transform);

        order.GetComponent<OrderUI>().data = orderData;
        order.GetComponent<OrderUI>().SetInfo();
        order.transform.localScale = Vector3.one;

        ordersUI.Add(orderData, order);

        orderTime = orderTime * 12f;
        GameManager.Instance.UIManager.SetTimer(orderTime);
        
    }*/


    // TESTING
    public void GenerateOrder()
    {
        palletObject.SetActive(true);
        //orderTime = 0;

        Order orderData = new Order(1, 0, 0, 0);
        currentOrder = orderData;

        GameObject order = Instantiate(orderUIPrefab, rightUIPanel.transform);

        order.GetComponent<OrderUI>().data = orderData;
        order.GetComponent<OrderUI>().SetInfo();
        //order.transform.SetParent(rightUIPanel.transform);
        order.transform.localScale = Vector3.one;

        //currentOrders.Add(orderData);
        ordersUI.Add(orderData, order);

        //Por que lo harcordearias a 10 segundos?
        // orderTime = 10f;
        // GameManager.Instance.UIManager.SetTimer(orderTime);
    }

    
}
