using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Characters.FirstPerson;
<<<<<<< HEAD
=======
using System.Diagnostics;
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739

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
<<<<<<< HEAD
    private GameObject CleanWaterAmountText;
    private GameObject DirtyWaterAmountText;
    private GameObject CleanWaterAmountImage;
    private GameObject DirtyWaterAmountImage;
    private GameObject HealthImage;
    private static List<AnimatorClipInfo> clipList = new List<AnimatorClipInfo>();

    private bool checkonce = true;
=======
    private GameObject WaterAmountText;
    private static List<AnimatorClipInfo> clipList = new List<AnimatorClipInfo>();
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739
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
<<<<<<< HEAD

        CleanWaterAmountText = GameObject.Find("CleanWaterAmount");
        DirtyWaterAmountText = GameObject.Find("DirtyWaterAmount");
        CleanWaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
        DirtyWaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.dirtywater;

        CleanWaterAmountImage = GameObject.Find("ContainerClean_Blue");
        DirtyWaterAmountImage = GameObject.Find("ContainerDirty_Green");
        HealthImage = GameObject.Find("HealthBar_Red");

=======
        WaterAmountText = GameObject.Find("WaterAmount");
        WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739
        WaterMinusText = GameObject.Find("MinusWater");
        WaterMinusText.GetComponent<Text>().text = "";
        animator = UI.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
<<<<<<< HEAD


=======
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739
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
<<<<<<< HEAD
                usewater(5, 1);
=======
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

>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739
                GameObject Task = GameObject.Find("Task05");
                GenerateStrike(Task);
            }
            if(InteractiveObject.name == "InteractiveObject02_Glass")
            {
<<<<<<< HEAD
                usewater(3, 2);
=======
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
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739

                GameObject Task = GameObject.Find("Task01");
                GenerateStrike(Task);
            }
            if (InteractiveObject.name == "InteractiveObject03_BathTab")
            {
<<<<<<< HEAD
                usewater(50, 3);
=======
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
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739

                GameObject Task = GameObject.Find("Task04");
                GenerateStrike(Task);
            }
            if (InteractiveObject.name == "InteractiveObject04_WashMachine")
            {
<<<<<<< HEAD
                usewater(60, 4);
=======
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
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739

                GameObject Task = GameObject.Find("Task03");
                GenerateStrike(Task);
            }
            if (InteractiveObject.name == "InteractiveObject05_Toilet")
            {
<<<<<<< HEAD
                usewater(6, 5);
=======
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
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739

                GameObject Task = GameObject.Find("Task02");
                GenerateStrike(Task);
            }
            WaterMinusText.SetActive(true);
            PlayAnim(animator);
<<<<<<< HEAD
            //audio.Play(0);
            Ifcollide = false;
        }

        if (checkonce)
        {
            if (WaterManager.Instance.Takebath)
            {
                GameObject Task = GameObject.Find("Task04");
                GenerateStrike(Task);
            }
            if (WaterManager.Instance.Washmachine)
            {
                GameObject Task = GameObject.Find("Task03");
                GenerateStrike(Task);
            }
            checkonce = false;
        }
=======
            audio.Play(0);
            Ifcollide = false;
        }
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739
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
<<<<<<< HEAD

    void usewater(int usage, int interact)
    {
        float dirtyusage = 0;
        float damagedirty = 0;
        if (WaterManager.Instance.water >= usage)
        {
            WaterMinusText.GetComponent<Text>().text = "- " + usage + "L";
            WaterMinusText.GetComponent<Text>().color = Color.blue;
            WaterManager.Instance.water -= usage;
            //print(WaterManager.Instance.water);
            //WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
        }
        else if (WaterManager.Instance.water > 0 && WaterManager.Instance.dirtywater >= usage)
        {
            dirtyusage = 1 - (WaterManager.Instance.water / usage);
            WaterMinusText.GetComponent<Text>().text = "- " + usage + "L";
            WaterMinusText.GetComponent<Text>().color = Color.yellow;
            WaterManager.Instance.dirtywater -= (usage - WaterManager.Instance.water);
            WaterManager.Instance.water = 0;
            //WaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
            

        }
        else if (WaterManager.Instance.water == 0 && WaterManager.Instance.dirtywater >= usage)
        {
            WaterMinusText.GetComponent<Text>().text = "- " + usage + "L";
            WaterMinusText.GetComponent<Text>().color = Color.green;
            WaterManager.Instance.dirtywater -= usage;
            dirtyusage = 1;
        }
        else
        {
            interact = 0;
            WaterMinusText.GetComponent<Text>().color = Color.gray;
            WaterMinusText.GetComponent<Text>().text = "Running out";
        }

        switch (interact)
        {
            case 1:
                WaterManager.Instance.Washhands = true;
                damagedirty = 20;
                break;
            case 2:
                WaterManager.Instance.Drink = true;
                damagedirty = 30;
                break;
            case 3:
                WaterManager.Instance.Takebath = true;
                damagedirty = 25;
                break;
            case 4:
                WaterManager.Instance.Washmachine = true;
                damagedirty = 15;
                break;
            case 5:
                WaterManager.Instance.Toilet = true;
                damagedirty = 10;
                break;
            case 0:
                break;
        }
        questmanager.CheckWinning();
        WaterManager.Instance.health -= (dirtyusage * damagedirty);
        CleanWaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
        DirtyWaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.dirtywater;
        CleanWaterAmountImage.GetComponent<Image>().fillAmount = WaterManager.Instance.water / 150;
        DirtyWaterAmountImage.GetComponent<Image>().fillAmount = WaterManager.Instance.dirtywater / 150;
        HealthImage.GetComponent<Image>().fillAmount = WaterManager.Instance.health / 100;
    }
=======
>>>>>>> 01eb0a4df9097700877b5eb298d229353c8e6739
}
