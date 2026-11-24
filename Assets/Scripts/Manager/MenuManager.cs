using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public float 
    waitToMenu //Tiempo que trasncurre entre la transicion del fondo negro
    ,FadeBetwennMenus; //Tiempo en el que el fundido aparece y desaparece
    Fader _Fader;
    enum MenuState
    {
        Titulo,       //0
        Menu,         // 1
        Opciones     // 2
    }
    MenuState _menuState;
    bool Tittle = true;
    [SerializeField] List<GameObject> Cameras = new List<GameObject>();
    [SerializeField] List<GameObject> Menus = new List<GameObject>();

    [SerializeField] GraphicRaycaster _MenuRaycast;

    void Start()
    {
        _Fader = GetComponentInChildren<Fader>();
        _menuState = MenuState.Titulo;
    }
    // Update is called once per frame
    void Update()
    {
        //aqui identifica si se presiono cualquier boton 
        bool _Input = Input.anyKey;
        
        //al identificar el boton pasa para salir del titulo
        if(_Input == true && _menuState == MenuState.Titulo)
            ChangeMenuState(1);
            Debug.Log("Pasa Al Menu :"+ _Input);
        

        ChangeBetwenMenus();
        
    }


    //Cambia entre los menus
    private void ChangeBetwenMenus()
    {
        switch(_menuState)
        {
            case MenuState.Titulo:
            
            ActiveDesactiveMenus();
            
            break;

            case MenuState.Menu:

            _MenuRaycast.enabled = true;
            if(Tittle == true)
                {
                    StartCoroutine(PigPog(FadeBetwennMenus,waitToMenu));
                }
                else
                {
                    ActiveDesactiveMenus();
                }
            

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
        Debug.Log("Menu: "+_menuState);
    }
    IEnumerator PigPog(float TimeIn_Out,float TimeWait)
    {
        _Fader.FadeIn(TimeIn_Out);
        yield return new WaitForSeconds(TimeWait);
        ActiveDesactiveMenus();
        yield return new WaitForSeconds(TimeWait);
        _Fader.FadeOut(TimeIn_Out);
        Tittle = false;
    }

}
