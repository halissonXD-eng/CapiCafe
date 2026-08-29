using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cafetera : MonoBehaviour
{
    Renderer _render;
    public Material Aprobado, Denegado;
    bool InCafetera;

    public TextMeshProUGUI Temporizador;

    InventariController _Inventary;

    [SerializeField] float Timer,secundero,PreCoffee;

    // Start is called before the first frame update
    void Start()
    {
         _render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(InCafetera == true && Input.GetKey(KeyCode.E))
        {
            Timer += Time.deltaTime;
            secundero = Mathf.FloorToInt(Timer % 60);

            Temporizador.text = string.Format("{0:00}",secundero);

            if(secundero >= PreCoffee)
            {
                _Inventary.HaveCoffee(true);
            }
        }
        else
        {
            Timer = 0;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        _Inventary = other.gameObject.GetComponent<InventariController>();

        if(other.gameObject.CompareTag("Player"))
        {
            _render.material = Aprobado;
            InCafetera = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        _render.material = Denegado;
        InCafetera = false;
    }
}
