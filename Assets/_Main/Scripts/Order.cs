using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public int redAmount;
    public int greenAmount;
    public int blueAmount;
    public int yellowAmount;
    
    public Order(int redBoxes, int greenBoxes, int blueBoxes, int yellowBoxes)
    { 
        redAmount = redBoxes;
        greenAmount = greenBoxes;
        blueAmount = blueBoxes;
        yellowAmount = yellowBoxes;
    }
}
