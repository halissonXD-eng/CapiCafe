using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaCambiodecamara : MonoBehaviour
{

    public GameObject camera1;
    
    bool CamaraActive = true;
    void Start()
    {
        camera1.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        CamaraActive = !CamaraActive;

        camera1.SetActive(CamaraActive);
    }
}
