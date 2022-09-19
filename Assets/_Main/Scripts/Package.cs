using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Package : MonoBehaviour
{
    [SerializeField] private PackageTypeSO data;
    private MeshRenderer meshRender;
    public PackageTypeSO Data { get; private set; }
    public string ColorName { get; private set; }

    private void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        SetData(data); 
    }

    public void SetData(PackageTypeSO newData) //we could use this for spawners
    {
        if (newData == null) return;

        Data = newData;
        meshRender.material = data.MaterialColor;
        ColorName = Data.PackageColor.ToString();
    }

    private void OnMouseOver()
    {
        var name = Data.PackageColor.ToString();
        UIManager.Instance.ShowName($"{name} package");
    }

    private void OnMouseExit()
    {
        UIManager.Instance.TurnOffName();
    }
}
