using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventariController : MonoBehaviour
{   
    public GameObject CupofCoffee;
    public bool _haveCoffee = false;

    public void HaveCoffee(bool YesorNo)
    {
        _haveCoffee = YesorNo;
        CupofCoffee.SetActive(_haveCoffee);
    }
}
