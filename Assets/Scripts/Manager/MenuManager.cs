using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    enum MenuState
    {
        titulo,    // 0 
        Menu,      // 1
        Opciones   // 2
    }
    MenuState _menuState;
    [SerializeField] List<GameObject> Cameras = new List<GameObject>();
    [SerializeField] List<GameObject> Menus = new List<GameObject>();

    void Start()
    {
        _menuState = MenuState.titulo;
    }
    // Update is called once per frame
    void Update()
    {
        //aqui identifica si se presiono cualquier boton 
        bool _Input = Input.anyKey;
        
        //al identificar el boton pasa para salir del titulo
        if(_Input == true)
            ChangeMenuState(1);
            Debug.Log("Pasa Al Menu :"+ _Input);
        
        ChangeBetwenMenus();
    }


    //Cambia entre los menus
    private void ChangeBetwenMenus()
    {
        switch(_menuState)
        {
            case MenuState.titulo:

            ActiveDesactiveMenus();

            break;

            case MenuState.Menu:

            ActiveDesactiveMenus();

            break;

            case MenuState.Opciones:

            ActiveDesactiveMenus();

            break;
        }
    }

    //Aqui se desactivan y se activan los menus segun el estado del MenuState
    void ActiveDesactiveMenus()
    {
        int _CamerasSize = Cameras.Count;
        int _MenusSize = Menus.Count;

        for (int i = 0; i < _CamerasSize && i < _MenusSize  ; i++)
        {

            Cameras[i].SetActive(false);
            Menus[i].SetActive(false);

            if(i == (int)_menuState)
            {
                Cameras[i].SetActive(true);
                Menus[i].SetActive(true);
            }

        }
    }

    //Llamas a esta funcion para avanzar al siguiente menu
    public void ChangeMenuState(int MenuNumber)
    {
        //aqui se obtiene el numero y lo convierte en un numero que pueda comprender el enmu
        _menuState = (MenuState)MenuNumber;
        Debug.Log(_menuState);
    }

}
