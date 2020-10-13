using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PolutionManager : MonoBehaviour
{
    private bool Ifcollide;
    private float startTime;
    float t;

    private GameObject CleanWaterAmountText;
    private GameObject DirtyWaterAmountText;
    private GameObject CleanWaterAmountImage;
    private GameObject DirtyWaterAmountImage;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        Ifcollide = false;

        CleanWaterAmountText = GameObject.Find("CleanWaterAmount");
        DirtyWaterAmountText = GameObject.Find("DirtyWaterAmount");
        CleanWaterAmountImage = GameObject.Find("ContainerClean_Blue");
        DirtyWaterAmountImage = GameObject.Find("ContainerDirty_Green");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Estimate which tags of collider this was hit.
        {
            Ifcollide = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))//Estimate which tags of collider this was hit.
        {
            Ifcollide = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0, 2, 0));
        t = Time.time - startTime;
        if (t > 10)
        {
            //gameObject.transform.localScale = new Vector3(40, 40, 40);
            GetComponent<Renderer>().material.color = Color.green;
        }
        if(t > 30)
        {
            Destroy(gameObject);
        }

        if (Ifcollide)
        {
            if (t < 10)
            {
                WaterManager.Instance.water += 15;
            }
            else
            {
                WaterManager.Instance.dirtywater += 15;
            }
            CleanWaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.water;
            DirtyWaterAmountText.GetComponent<Text>().text = "" + WaterManager.Instance.dirtywater;
            CleanWaterAmountImage.GetComponent<Image>().fillAmount = WaterManager.Instance.water / 150;
            DirtyWaterAmountImage.GetComponent<Image>().fillAmount = WaterManager.Instance.dirtywater / 150;
            Ifcollide = false;
            Destroy(gameObject);
        }
    }
}
