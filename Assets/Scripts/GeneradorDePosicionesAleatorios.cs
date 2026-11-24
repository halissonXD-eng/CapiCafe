using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDePosicionesAleatorios : MonoBehaviour
{
    public Material Aprobado, Denegado;
    Renderer _render;

    public List<GameObject> SpotsNPC;

    int MinSpots,MaxSpots;
    bool InMostrador;

    void Start()
    {
        _render = GetComponent<MeshRenderer>();
        MinSpots = 0;
        MaxSpots = SpotsNPC.Count;
    }

    void Update()
    {
        if(InMostrador == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                int RamdNumber = Random.Range(MinSpots,MaxSpots);

                if(SpotsNPC[RamdNumber].activeSelf == false)
                {
                    SpotsNPC[RamdNumber].SetActive(true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _render.material = Aprobado;
            InMostrador = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        _render.material = Denegado;
        InMostrador = false;
    }
}
