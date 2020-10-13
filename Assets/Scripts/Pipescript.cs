using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Pipescript : MonoBehaviour
{
    float[] rotations = { 0, 90, 270 };

    public float correctRotation1;
    public float correctRotation2;
    [SerializeField]
    bool isPlaced = false;

    PipeManager pipeManager;
    
    private void Awake()
    {
        pipeManager = GameObject.Find("PipeManager").GetComponent<PipeManager>();
    }

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (transform.eulerAngles.z == correctRotation1 || transform.eulerAngles.z == correctRotation2)
        {
            isPlaced = true;
            pipeManager.correctMove();
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if ((transform.eulerAngles.z == correctRotation1 || transform.eulerAngles.z == correctRotation2) && isPlaced == false)
        {
            isPlaced = true;
            pipeManager.correctMove();
        }
        else if (isPlaced == true)
        {
            isPlaced = false;
            pipeManager.wrongMove();
        }
    }
}
