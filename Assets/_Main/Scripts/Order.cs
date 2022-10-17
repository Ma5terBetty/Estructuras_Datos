using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int redAmount;
    public int greenAmount;
    public int blueAmount;
    public int yellowAmount;
    
    public Order(int redBoxes = 0, int greenBoxes = 0, int blueBoxes = 0, int yellowBoxes = 0)
    { 
        redAmount = redBoxes;
        greenAmount = greenBoxes;
        blueAmount = blueBoxes;
        yellowAmount = yellowBoxes;
    }

    public void Add(string colorName)
    {
        switch (colorName)
        {
            case "red": redAmount++;
                break;
            case "blue": blueAmount++;
                break;
            case "green": greenAmount++;
                break;
            case "yellow": yellowAmount++;
                break;
            default: Debug.LogError("The name of the color is null or is nor from RGBY");
                break;
        }

        Debug.Log($"Color counter is: R:{redAmount} / G: {greenAmount} / B:{blueAmount} / Y:{yellowAmount}");
    }

    public void UpdateAmounts(string colorName, int amount)
    {
        switch (colorName)
        {
            case "red":
                redAmount = amount;
                break;
            case "blue":
                blueAmount = amount;
                break;
            case "green":
                greenAmount = amount;
                break;
            case "yellow":
                yellowAmount = amount;
                break;
            default: Debug.LogError("The name of the color is null or is nor from RGBY");
                break;
        }

        Debug.Log($"Color counter is: R:{redAmount} / G: {greenAmount} / B:{blueAmount} / Y:{yellowAmount}");
    }

    public void Reset()
    { 
        redAmount=0;
        greenAmount=0;
        blueAmount=0;
        yellowAmount=0;
    }

    public void Print()
    {
        Debug.Log($"Color counter is: R:{redAmount} / G: {greenAmount} / B:{blueAmount} / Y:{yellowAmount}");
    }
}
