using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_Activate : MonoBehaviour
{
    public Material InteractiveMat;

    void Start()
    {
        InteractiveMat.SetFloat("_Outline", 0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Estimate which tags of collider this was hit.
        {
            InteractiveMat.SetFloat("_Outline", 4);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Estimate which tags of collider this was hit.
        {
            InteractiveMat.SetFloat("_Outline", 0);
        }
    }
    void Update()
    {
        
    }
}
