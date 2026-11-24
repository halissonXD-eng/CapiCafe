using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpotDespawn : MonoBehaviour
{
    [SerializeField] float TiempoDesaparicion, Timer, secundero, GraceSeconds;
    public TextMeshProUGUI Temporizador;
    BoxCollider Trigger;
    InventariController _Inventary;
    bool _haveCoffee;
    MoneyManager _MoneyManager;
    void Start()
    {
        Temporizador = GetComponentInChildren<TextMeshProUGUI>();
        Trigger = GetComponentInChildren<BoxCollider>();
        _MoneyManager = FindAnyObjectByType<MoneyManager>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        secundero = Mathf.FloorToInt(Timer % 60);

        Temporizador.text = string.Format("{0:00}",secundero);

        if(secundero+GraceSeconds >= TiempoDesaparicion)
        {
            Timer = 0;
            gameObject.SetActive(false);
        }

        if(_haveCoffee == true && Input.GetKey(KeyCode.E))
        {
            _Inventary.HaveCoffee(false);
            _MoneyManager.addMoney(200);
            Timer = 0;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        _Inventary = other.gameObject.GetComponent<InventariController>();
        _haveCoffee = _Inventary._haveCoffee;
    }

}
