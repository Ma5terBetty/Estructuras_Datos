using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "SO/Level", order = 0)]
public class LevelSO : ScriptableObject
{
    [SerializeField] private int amountOfOrders = 3;

    public int AmountOfOrders => amountOfOrders;
}
