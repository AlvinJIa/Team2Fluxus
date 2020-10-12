using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SwitchCamera : MonoBehaviour
{
    public Camera PipeCamera;
    public Camera FPCamera;
    public GameObject PipeManager;
    public GameObject PipeScene;
    public GameObject UI;
    public GameObject Player;

    private bool IfPiped;
    private Animator animator;
    //private bool canDoAction = true;
    void Start()
    {
        PipeScene.SetActive(false);
        PipeCamera.gameObject.SetActive(false);
        IfPiped = false;
        UI.transform.GetChild(0).gameObject.SetActive(false);
        UI.transform.GetChild(1).gameObject.SetActive(false);
        UI.transform.GetChild(2).gameObject.SetActive(false);
        UI.transform.GetChild(3).gameObject.SetActive(false);
        animator = GameObject.Find("QuestList").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    { 
        if (collision.gameObject.CompareTag("Player") && IfPiped == false)//Estimate which tags of collider this was hit.
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PipeScene.SetActive(true);
            PipeCamera.gameObject.SetActive(true);
            FPCamera.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if(PipeManager.GetComponent<PipeManager>().winning == true)
        {
            IfPiped = true;
            FPCamera.gameObject.SetActive(true);
            PipeCamera.gameObject.SetActive(false);
            PipeScene.SetActive(false);
            UI.transform.GetChild(0).gameObject.SetActive(true);
            UI.transform.GetChild(1).gameObject.SetActive(true);
            UI.transform.GetChild(2).gameObject.SetActive(true);
            UI.transform.GetChild(3).gameObject.SetActive(true);
            Player.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            animator.SetBool("IfShiftIn", true);
        }
    }
}
