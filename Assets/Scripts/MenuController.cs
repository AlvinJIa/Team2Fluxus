using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject WinningMenu;
    void Start()
    {
        WinningMenu.SetActive(false);
    }
    public void ChangeDay(string sceneName)
    {
        //Application.LoadLevel(sceneName);
    }
    void Update()
    {
        
    }
}
