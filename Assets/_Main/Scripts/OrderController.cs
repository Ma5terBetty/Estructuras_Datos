using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OrderController : MonoBehaviour
{
    private struct NewOrder
    {
        public Order Order { get; private set; }
        public GameObject GameObject { get; private set; }

        public NewOrder(Order order, GameObject gameObject)
        {
            Order = order;
            GameObject = gameObject;
        }
    }

    private MyTree<NewOrder> _orders = new MyTree<NewOrder>();
    private int _orderIndex;
    private Order _palletOrder;
    private Order _tempOrder = new Order();
    private float _totalOrderTime;
    [SerializeField] private GameObject palletObject;
    [SerializeField] private GameObject rightUIPanel;
    [SerializeField] private GameObject orderUIPrefab;
    [SerializeField] private float individualOrderTime = 12f;

    private void Start()
    {
        Suscribe();

        GameManager.Instance.SetOrderController(this);
        _orders.Add(new NewOrder());
        //_currentOrder = new Order();
        TurnPalletOff();    
    }
    public void CheckForOrder(bool isTimeOver = false)
    {
        if (isTimeOver)
        {
            if (IsOrderComplete())
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
            if (_orders[_orderIndex].Order == null) Debug.Log("Se rompio order");
            if (_palletOrder == null) Debug.Log("Se rompio pallet");

            if (IsOrderComplete())
            {
                Debug.Log("Se termina");
                GameManager.Instance.OrderCompleted();
            }
        }
    }

    private bool IsOrderComplete()
    {
        return _orders[_orderIndex].Order.redAmount == _palletOrder.redAmount
               && _orders[_orderIndex].Order.greenAmount == _palletOrder.greenAmount
               && _orders[_orderIndex].Order.blueAmount == _palletOrder.blueAmount
               && _orders[_orderIndex].Order.yellowAmount == _palletOrder.yellowAmount;
    }

    void TurnPalletOff()
    {
        if(palletObject)
            palletObject.SetActive(false);
    }

    void TurnPalletOn()
    {
        if(palletObject)
            palletObject.SetActive(true);
    }


    public void GenerateOrder()
    {
        palletObject.SetActive(true);
        _totalOrderTime = 0;

        int[] temp = new int[4];
        for (int i = 0; i < temp.Length; i++)
        { 
            temp[i] = Mathf.RoundToInt(Random.Range(0, 4));
            individualOrderTime += temp[i];
        }
        var orderData = new Order(temp[0], temp[1], temp[2], temp[3]);
        var order = Instantiate(orderUIPrefab, rightUIPanel.transform);
        
        
        _orders.Add(new NewOrder(orderData, order));
        _orderIndex++;
        //_currentOrder = orderData;

        order.GetComponent<OrderUI>().data = _orders[_orderIndex].Order;
        order.GetComponent<OrderUI>().SetInfo();
        order.transform.localScale = Vector3.one;

        _totalOrderTime = individualOrderTime * 3f;
        UIManager.Instance.SetTimer(_totalOrderTime);
        //UIManager.Instance.SetTimer(5);

        /*tempOrder = cleanOder;
        palletObject.GetComponent<Pallet>().currentOrder = cleanOder;
        palletOrder = palletObject.gameObject.GetComponent<Pallet>().currentOrder;*/
        palletObject.GetComponent<Pallet>().CurrentOrder.Reset();
        _palletOrder = palletObject.gameObject.GetComponent<Pallet>().CurrentOrder;
        palletObject.gameObject.GetComponent<Pallet>().CurrentOrder.Reset();
    }


    // TESTING
    /*public void GenerateOrder()
    {
        //palletObject.SetActive(true);
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
        //-Porque es la sección de Testing, el generador posta lo hace solito.
        // orderTime = 10f;
        // GameManager.Instance.UIManager.SetTimer(orderTime);

        tempOrder = cleanOder;
        palletObject.GetComponent<Pallet>().currentOrder = tempOrder;
        palletOrder = palletObject.gameObject.GetComponent<Pallet>().currentOrder;
        if (palletOrder == null) Debug.Log("Se rompio pallet");
    }*/

    private void Suscribe()
    {
        GameManager.OnTruckArrives += TurnPalletOn;
        GameManager.OnTruckLeaves += TurnPalletOff;
        GameManager.OnChangedScene += Unsuscribe;
    }

    private void Unsuscribe()
    {
        GameManager.OnTruckArrives -= TurnPalletOn;
        GameManager.OnTruckLeaves -= TurnPalletOff;
    }


}
