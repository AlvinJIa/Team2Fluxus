using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    //public GameObject QuestList;
    //public GameObject UI;

    private Animator animator;
    void Start()
    {
        animator = GameObject.Find("QuestList").GetComponent<Animator>();

        //always false at start
        WaterManager.Instance.Drink = false;
        WaterManager.Instance.Washhands = false;
        WaterManager.Instance.Toilet = true;

        //randomly set to true
        WaterManager.Instance.Takebath = false;
        WaterManager.Instance.Washmachine = false;

        int rand = Random.Range(0, 99);
        if (rand <= 79)
            WaterManager.Instance.Takebath = true;

        rand = Random.Range(0, 99);
        if (rand <= 89)
            WaterManager.Instance.Washmachine = true;
    }

    public void CheckWinning()
    {
        WaterManager.Instance.Winnning = WaterManager.Instance.Drink && WaterManager.Instance.Washhands &&
            WaterManager.Instance.Toilet && WaterManager.Instance.Takebath && WaterManager.Instance.Washmachine;
        if (WaterManager.Instance.Winnning)
        {
            //goto next day
            animator.SetBool("IfShiftOut", true);
        }
    }
}
