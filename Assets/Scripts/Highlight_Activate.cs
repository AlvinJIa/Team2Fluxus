using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Characters.FirstPerson;

public class Highlight_Activate : MonoBehaviour
{
    public Material InteractiveMat;
    public float OutlineWidth;
    public GameObject InteractiveObject;
    public GameObject UI;
    public GameObject Player;

    private bool Ifcollide;
    private Animator animator;
    private GameObject WaterMinusText;
    private GameObject WaterAmountText;
    private static List<AnimatorClipInfo> clipList = new List<AnimatorClipInfo>();
    //private int WaterAmount;

    void Start()
    {
        InteractiveMat.SetFloat("_Outline", 0);
        Ifcollide = false;
        WaterAmountText = GameObject.Find("WaterAmount");
        WaterAmountText.GetComponent<Text>().text = "" + Player.GetComponent<FirstPersonController>().Water;//use pointer later
        WaterMinusText = GameObject.Find("MinusWater");
        WaterMinusText.GetComponent<Text>().text = "";
        animator = UI.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Estimate which tags of collider this was hit.
        {
            InteractiveMat.SetFloat("_Outline", OutlineWidth);
            Ifcollide = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Estimate which tags of collider this was hit.
        {
            InteractiveMat.SetFloat("_Outline", 0);
            Ifcollide = false;
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Ifcollide == true)
        {
            if(InteractiveObject.name == "InteractiveObject01_WashTab")
            {
                WaterMinusText.GetComponent<Text>().text = "- 5L";
                Player.GetComponent<FirstPersonController>().Water -= 5;
                print(Player.GetComponent<FirstPersonController>().Water);
                WaterAmountText.GetComponent<Text>().text = "" + Player.GetComponent<FirstPersonController>().Water;
            }
            if(InteractiveObject.name == "InteractiveObject02_Glass")
            {
                WaterMinusText.GetComponent<Text>().text = "- 3L";
                Player.GetComponent<FirstPersonController>().Water -= 3;
                print(Player.GetComponent<FirstPersonController>().Water);
                WaterAmountText.GetComponent<Text>().text = "" + Player.GetComponent<FirstPersonController>().Water;
            }
            if (InteractiveObject.name == "InteractiveObject03_BathTab")
            {
                WaterMinusText.GetComponent<Text>().text  = "- 50L";
                Player.GetComponent<FirstPersonController>().Water -= 50;
                print(Player.GetComponent<FirstPersonController>().Water);
                WaterAmountText.GetComponent<Text>().text = "" + Player.GetComponent<FirstPersonController>().Water;
            }
            if (InteractiveObject.name == "InteractiveObject04_WashMachine")
            {
                WaterMinusText.GetComponent<Text>().text  = "- 60L";
                Player.GetComponent<FirstPersonController>().Water -= 60;
                print(Player.GetComponent<FirstPersonController>().Water);
                WaterAmountText.GetComponent<Text>().text = "" + Player.GetComponent<FirstPersonController>().Water;
            }
            WaterMinusText.SetActive(true);
            PlayAnim(animator);
            Ifcollide = false;
        }
    }
    public void PlayAnim(Animator animator)
    {
        StartCoroutine(PlayAnimation(animator));
    }
    public IEnumerator PlayAnimation(Animator animator)
    {
        animator.SetBool("IfPlayAnim", true);

        yield return new WaitForSeconds(1);

        animator.SetBool("IfPlayAnim", false);

        yield return new WaitForSeconds(1);

        WaterMinusText.SetActive(false);
    }
}
