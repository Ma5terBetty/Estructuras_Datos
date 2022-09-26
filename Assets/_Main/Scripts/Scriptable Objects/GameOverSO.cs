using UnityEngine;
using TMPro;

[System.Serializable]
public struct MyText
{
    [SerializeField] private string text;
    [SerializeField] private TMP_FontAsset font;
    [SerializeField] private Color color;
    
    public string Text => text;
    public TMP_FontAsset Font => font;
    public Color Color => color;
}

[System.Serializable]
public struct MyBackground
{
    [SerializeField] private Sprite image;
    [SerializeField] private Color color;
    [SerializeField] private Material material;

    public Sprite Image => image;
    public Color Color => color;
    public Material Material => material;
}
[CreateAssetMenu(menuName = "UI", fileName = "Screen/GameOver", order = 0)]
public class GameOverSO : ScriptableObject
{
    [Header("Text")]
    [SerializeField] private MyText tittle;
    [SerializeField] private MyText message;
    
    [Header("Background")]
    [SerializeField] private MyBackground background;

    public MyText Tittle => tittle;
    public MyText Message => message;
    public MyBackground Background => background;
}
