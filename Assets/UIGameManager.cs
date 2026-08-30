using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameManager : MonoBehaviour
{
    bool IsMenu = false;

    public GameObject _Menu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ActiveMenuInGame();
        }    
    }

    public void ActiveMenuInGame()
    {
        Cursor.lockState = IsMenu ? CursorLockMode.Locked :CursorLockMode.None;
        IsMenu = !IsMenu;
        Time.timeScale = IsMenu ? 0f : 1f; //aqui le dise si el menu esta activo pausa el tiempo (el  primer resultado), y despausa al no estar en el menu (la segunda variable)
        _Menu.SetActive(IsMenu);
    }
}
