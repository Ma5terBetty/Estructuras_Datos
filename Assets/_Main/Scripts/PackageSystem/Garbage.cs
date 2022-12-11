using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Package
{
    [SerializeField] private PackageTypeSO data;
    
    protected override void Awake()
    {
        base.Awake();
        SetData(data);
    }

    public override void PickUp(Transform employee, Transform hand)
    {
        var em = employee.gameObject.GetComponent<Employee>();
        if (!em || em.GetData().Role != EmployeeRole.GarbageCollector) return;
        base.PickUp(employee, hand);
    }

    protected override void OnMouseOver()
    {
        var name = Data.Id.ToString();
        UIManager.Instance.ShowName($"{name}");
    }
}
