using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public static WaterManager Instance { get; private set;}

    public float water;

    //fix quests
    public bool Washhands = false;
    public bool Drink = false;
    public bool Toilet = false;
    // random quests
    public bool Takebath = false;
    public bool Washmachine = false;

    public bool Winnning = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
