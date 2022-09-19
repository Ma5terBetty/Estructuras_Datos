using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [SerializeField]
    GameObject redBox;
    [SerializeField]
    GameObject greenBox;
    [SerializeField]
    GameObject blueBox;
    [SerializeField]
    GameObject yellowBox;

    public Order data;
    void Start()
    {
        redBox.GetComponentInChildren<Image>().color = Color.red;
        greenBox.GetComponentInChildren<Image>().color = Color.green;
        blueBox.GetComponentInChildren<Image>().color = Color.blue;
        yellowBox.GetComponentInChildren<Image>().color = Color.yellow;
    }
    public void SetInfo()
    { 
        redBox.GetComponentInChildren<Text>().text = data.redAmount.ToString();
        greenBox.GetComponentInChildren<Text>().text = data.greenAmount.ToString();
        blueBox.GetComponentInChildren<Text>().text = data.blueAmount.ToString();
        yellowBox.GetComponentInChildren<Text>().text = data.yellowAmount.ToString();

        if (data.redAmount == 0) redBox.SetActive(false);
        if (data.greenAmount == 0) greenBox.SetActive(false);
        if (data.blueAmount == 0) blueBox.SetActive(false);
        if (data.yellowAmount == 0) yellowBox.SetActive(false);
    }
}
