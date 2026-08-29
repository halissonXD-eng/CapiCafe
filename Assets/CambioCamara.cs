using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public GameObject SecondCamera;

    bool CameraActive = true;
    private void OnTriggerExit(Collider other) 
    {
        CameraActive = !CameraActive;

        SecondCamera.SetActive(CameraActive);
    }
}
