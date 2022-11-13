using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance = null;
    private static readonly object Padlock = new object();

    [field: SerializeField]
    public LevelSO LevelData { get; private set; }
    
    private LevelManager()
    {
    }

    public static LevelManager Instance
    {
        get
        {
            lock (Padlock)
            {
                return _instance;
            }
        }
    }
    private void Awake()
    {
        lock (Padlock)
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
    }
}
