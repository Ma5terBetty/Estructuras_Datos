using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConveyorTool : MonoBehaviour
{
    [SerializeField]
    GameObject conveyor;

    public int amount;

    Mesh mesh;
    public void Build(int amount)
    {
        Clear();
        mesh = conveyor.transform.GetChild(2).GetComponent<MeshFilter>().sharedMesh;
        float boxSize = mesh.bounds.size.z;
        int counter = 0;

        while (counter < amount)
        {
            Vector3 position = transform.position;
            Vector3 finalPosition = new Vector3(position.x + (boxSize * counter * transform.forward.x), position.y, position.z + (boxSize * counter* transform.forward.z));
            //GameObject temp = Instantiate(conveyor, finalPosition, Quaternion.Euler(transform.rotation.eulerAngles));
            var temp = (GameObject)PrefabUtility.InstantiatePrefab(conveyor);
            temp.transform.position = finalPosition;
            temp.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);
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
