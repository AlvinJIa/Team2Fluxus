using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PipeManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;
    //public GameObject UI;
    //public Camera PipeCamera;
    //public Camera FPCamera;

    private float startTime;
    private int watergain;

    int totalPipes = 0;
    [SerializeField]
    int correctedPipes = 0;
    public bool winning = false;

    void Start()
    {
        totalPipes = PipesHolder.transform.childCount;
        Pipes = new GameObject[totalPipes];
        for (int i = 0; i < Pipes.Length; i++) 
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }

        startTime = Time.time;
    }
    
    public void correctMove()
    {
        correctedPipes++;
        if(correctedPipes == totalPipes)
        {
            Debug.Log("you win!");
            winning = true;
            WaterManager.Instance.water += watergain;
        }
    }

    public void wrongMove()
    {
        correctedPipes--;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Q))//DEBUG To WIn
            winning = true;
        if (winning)
            return;
        float t = Time.time - startTime;
        watergain = 150 - (2 * (int)t);
    }
}
