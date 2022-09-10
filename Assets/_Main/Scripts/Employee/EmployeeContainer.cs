using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmployeeContainer : MonoBehaviour
{
    [Header("Spawner Values")]
    [Range(1, 15)]
    [SerializeField] private int ammountToSpawn;
    [Range(3, 15)]
    [SerializeField] private float spawnRadius;
    [Range(1,5)]
    [Tooltip("Min Distance Between Employees")]
    [SerializeField] private float minDistance;
    [Header("Employee Values")]
    [SerializeField] private GameObject employeeGo;

    private List<GameObject> _employees = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEmployee();
    }

    private Vector3 CreatePosition()
    {
        Vector3 newPosition = Vector3.zero;
        var position = transform.position;
        var newX = Random.Range(position.x + spawnRadius, position.x - spawnRadius);
        var newZ = Random.Range(position.z + spawnRadius, position.z - spawnRadius);;

        newPosition = new Vector3(newX, 0, newZ);
        
        return newPosition;
    }

    private bool CheckDistance(Vector3 position)
    {
        int employeeCount = _employees.Count;
        if (employeeCount == 0) return false;

        for (int i = 0; i < employeeCount; i++)
        {
            var employeePos = _employees[i].transform.position;
            var distance = Vector3.Distance(position, employeePos);
            if (distance <= minDistance) return true;
        }
        
        return false;
    }

    private void SpawnEmployee()
    {
        for (int i = 0; i < ammountToSpawn; i++)
        {
            var newPosition = CreatePosition();

            if (CheckDistance(newPosition)) newPosition = CreatePosition();

            var newEmployee = Instantiate(employeeGo, newPosition, Quaternion.identity, transform);
            _employees.Add(newEmployee);
        }
    }
#if UNITY_EDITOR
    [ContextMenu("Re Spawn")]
    public void TestVoid()
    {
        foreach (var t in _employees)
        {
            Destroy(t);
        }

        _employees.Clear();
        
        SpawnEmployee();
    }
#endif

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
