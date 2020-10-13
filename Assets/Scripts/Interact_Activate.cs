using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Characters.FirstPerson;
using System.Diagnostics;

public class Interact_Activate : MonoBehaviour
{
    public Material InteractiveMat;
    public float OutlineWidth;
    public GameObject InteractiveObject;
    public GameObject UI;
    public GameObject Player;
    public Image StrikeThrough;

    private bool Ifcollide;
    private Animator animator;
    private GameObject WaterMinusText;
    private GameObject WaterAmountText;
    private static List<AnimatorClipInfo> clipList = new List<AnimatorClipInfo>();
    QuestManager questmanager;
    //[SerializeField] private Image healthImage;
    private AudioSource audio;

    void Awake()
    {
        questmanager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
    }

    void Start()
    {
        InteractiveMat.SetFloat("_Outline", 0);
        Ifcollide = false;
        WaterAmountText = GameObject.Find("WaterAmount");
        WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
        WaterMinusText = GameObject.Find("MinusWater");
        WaterMinusText.GetComponent<Text>().text = "";
        animator = UI.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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
            if (InteractiveObject.name == "InteractiveObject01_WashTab")
            {
                if (WaterManager.Instance.water >= 5)
                {
                    WaterMinusText.GetComponent<Text>().text = "- 5L";
                    WaterManager.Instance.water -= 5;
                    //print(WaterManager.Instance.water);
                    WaterManager.Instance.Washhands = true;
                    questmanager.CheckWinning();
                    WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
                }
                else
                {
                    WaterMinusText.GetComponent<Text>().text = "Running out";
                }

                GameObject Task = GameObject.Find("Task05");
                GenerateStrike(Task);
            }
            if(InteractiveObject.name == "InteractiveObject02_Glass")
            {
                if (WaterManager.Instance.water >= 3)
                {
                    WaterMinusText.GetComponent<Text>().text = "- 3L";
                    WaterManager.Instance.water -= 3;
                    //print(WaterManager.Instance.water);
                    WaterManager.Instance.Drink = true;
                    questmanager.CheckWinning();
                    WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
                }
                else
                {
                    WaterMinusText.GetComponent<Text>().text = "Running out";
                }

                GameObject Task = GameObject.Find("Task01");
                GenerateStrike(Task);
            }
            if (InteractiveObject.name == "InteractiveObject03_BathTab")
            {
                if (WaterManager.Instance.water >= 50)
                {
                    //print(WaterManager.Instance.water);
                    WaterMinusText.GetComponent<Text>().text = "- 50L";
                    WaterManager.Instance.water -= 50;
                    //print(WaterManager.Instance.water);
                    WaterManager.Instance.Takebath = true;
                    questmanager.CheckWinning();
                    WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
                }
                else
                {
                    WaterMinusText.GetComponent<Text>().text = "Running out";
                }

                GameObject Task = GameObject.Find("Task04");
                GenerateStrike(Task);
            }
            if (InteractiveObject.name == "InteractiveObject04_WashMachine")
            {
                if (WaterManager.Instance.water >= 60)
                {
                    WaterMinusText.GetComponent<Text>().text = "- 60L";
                    WaterManager.Instance.water -= 60;
                    //print(WaterManager.Instance.water);
                    WaterManager.Instance.Washmachine = true;
                    questmanager.CheckWinning();
                    WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
                }
                else
                {
                    WaterMinusText.GetComponent<Text>().text = "Running out";
                }

                GameObject Task = GameObject.Find("Task03");
                GenerateStrike(Task);
            }
            if (InteractiveObject.name == "InteractiveObject05_Toilet")
            {
                if (WaterManager.Instance.water >= 6)
                {
                    WaterMinusText.GetComponent<Text>().text = "- 6L";
                    WaterManager.Instance.water -= 6;
                    //print(WaterManager.Instance.water);
                    WaterManager.Instance.Washhands = true;
                    questmanager.CheckWinning();
                    WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
                }
                else
                {
                    WaterMinusText.GetComponent<Text>().text = "Running out";
                }

                GameObject Task = GameObject.Find("Task02");
                GenerateStrike(Task);
            }
            WaterMinusText.SetActive(true);
            PlayAnim(animator);
            audio.Play(0);
            Ifcollide = false;
        }
    }
    private void GenerateStrike(GameObject Task)
    {
        Image st = Instantiate(StrikeThrough, Vector3.zero, Quaternion.identity);
        st.transform.SetParent(Task.transform, false);
        st.rectTransform.anchoredPosition = Vector3.zero;
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
