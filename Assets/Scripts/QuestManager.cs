using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class QuestManager : MonoBehaviour
{
    //public GameObject QuestList;
    public GameObject WinningMenu;
    public GameObject Player;

    private Animator animator;
    private Animator animator01;

    void Start()
    {
        animator = GameObject.Find("QuestList").GetComponent<Animator>();
        animator01 = WinningMenu.GetComponent<Animator>();

        //always false at start
        WaterManager.Instance.Drink = false;
        WaterManager.Instance.Washhands = false;
        WaterManager.Instance.Toilet = false;

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
        if (WaterManager.Instance.Winnning || Input.GetKeyDown(KeyCode.P))
            {
            //Go to next day
            animator.SetBool("IfShiftOut", true);

            //Controller lock
            //Debug.Log("111");
            Player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            WinningMenuZoomIn(animator01);
        }
    }
    public void WinningMenuZoomIn(Animator animator01)
    {
        StartCoroutine(WMZoomIn(animator));
    }
    public IEnumerator WMZoomIn(Animator animator01)
    {
        WinningMenu.SetActive(true);

        yield return new WaitForSeconds(1);

        animator01.SetBool("IfWinning", true);
    }
}
