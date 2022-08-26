using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorTool : MonoBehaviour
{
    [SerializeField]
    GameObject conveyor;

    public int amount;

    BoxCollider convColl;
    public void Build(int amount)
    {
        Clear();
        convColl = conveyor.GetComponent<BoxCollider>();
        float boxSize = convColl.size.z;
        int counter = 0;
        HeightCorrection(convColl.size.y / 2);

        while (counter < amount)
        {
            Vector3 position = transform.position;
            Vector3 finalPosition = new Vector3(position.x, position.y, position.z + (boxSize * counter));
            GameObject temp = Instantiate(conveyor, finalPosition, Quaternion.identity);
            temp.transform.parent = transform;
            counter++;
        }
    }

    void HeightCorrection(float height)
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, 0, pos.z);
        transform.position = new Vector3(pos.x, height, pos.z);
    }

    void Clear()
    {
        var tempArray = new GameObject[transform.childCount];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = transform.GetChild(i).gameObject;
        }

        foreach (var child in tempArray)
        { 
            DestroyImmediate(child);
        }
    }
}
