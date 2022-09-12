using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdersManager : MonoBehaviour
{
    [SerializeField]
    GameObject rightUIPanel;
    [SerializeField]
    GameObject orderUIPrefab;

    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.5f)
        {
            GenerateOrder();
            timer = 0f;        
        }
    }
    void CheckOrder()
    {

    }

    void GenerateOrder()
    {
        int[] temp = new int[4];
        for (int i = 0; i < temp.Length; i++)
        { 
            temp[i] = Mathf.RoundToInt(Random.Range(0, 4));
        }
        Order orderData = new Order(temp[0], temp[1], temp[2], temp[3]);

        GameObject order = Instantiate(orderUIPrefab);

        order.GetComponent<OrderUI>().data = orderData;
        order.GetComponent<OrderUI>().SetInfo();
        order.transform.SetParent(rightUIPanel.transform);
        order.transform.localScale = Vector3.one;

    }
}
