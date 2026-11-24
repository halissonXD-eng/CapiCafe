using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float money;
    public TextMeshProUGUI MoneyDisplay;

    public void addMoney(float MoneyAdded)
    {
        money += MoneyAdded;
        MoneyDisplay.text = money.ToString();
    }
}
