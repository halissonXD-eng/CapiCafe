using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(EmpezarInstrucciones());
    }

    public void TerminarInstrucciones()
    {
        Time.timeScale = 1f; 
        StopAllCoroutines();
        Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator EmpezarInstrucciones()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
}
