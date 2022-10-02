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

[System.Serializable]
public struct MyButtonColors
{
    [SerializeField] private Color normal;
    [SerializeField] private Color highlighted;
    [SerializeField] private Color pressed;
    [SerializeField] private Color selected;
    [SerializeField] private Color disable;
    
    public Color Normal => normal;
    public Color Highlighted => highlighted;
    public Color Pressed => pressed;
    public Color Selected => selected;
    public Color Disable => disable;
}

[CreateAssetMenu(menuName = "UI", fileName = "Screen/GameOver", order = 0)]
public class GameOverSO : ScriptableObject
{
    [SerializeField] private bool isGameOver;
    
    [Header("Texts")]
    [SerializeField] private MyText tittle;
    [SerializeField] private MyText message;
    
    [Header("Background")]
    [SerializeField] private MyBackground background;
    
    [Header("Buttons")]
    [SerializeField] private MyText buttonOne;
    [SerializeField] private MyText buttonTwo;
    [SerializeField] private MyButtonColors buttonColors;

    public bool IsGameOver => isGameOver;
    public MyText Tittle => tittle;
    public MyText Message => message;
    public MyBackground Background => background;
    public MyText ButtonOne => buttonOne;
    public MyText ButtonTwo => buttonTwo;
    public MyButtonColors ButtonColors => buttonColors;
}
