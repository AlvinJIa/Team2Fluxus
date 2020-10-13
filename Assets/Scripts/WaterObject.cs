using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObject : MonoBehaviour
{
    public GameObject[] spawnees;
    public Transform[] spawnPos;
    int[] bitmap;

    int randomInt;
    int randomPos;
    // Update is called once per frame

    void Start()
    {
        bitmap = new int[15];
    }

    void Update()
    {
        if (WaterManager.Instance.spawn == true)
        {
            for (int i = 0; i < 10; i++) 
                SpawnRandom();
            WaterManager.Instance.spawn = false;
        }
    }

    void SpawnRandom()
    {
        randomInt = Random.Range(0, spawnees.Length);
        randomPos = Random.Range(0, spawnPos.Length);
        while (bitmap[randomPos] == 1)
        {
            randomPos = Random.Range(0, spawnPos.Length);
        }
        bitmap[randomPos] = 1;
        GameObject waters = Instantiate(spawnees[randomInt], spawnPos[randomPos].position, spawnPos[randomPos].rotation);
        //waters.transform.localScale = new Vector3(20, 20, 20);
    }
}
