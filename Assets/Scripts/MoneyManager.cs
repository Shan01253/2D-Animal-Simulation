using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    public Text moneyText;
    public int money;
    private float timer;
    private int moneyToAdd;

    private void Start()
    {
        money = 100;
        DispayCurrentMoney();
        moneyToAdd = 30;
        timer= 0f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        moneyText.text = "Money: " + money.ToString();
        AddMoney();
    }

    void AddMoney()
    {
        if (timer > 5f)
        {
            money += moneyToAdd;
            timer = 0f;
            moneyText.text = "Money: " + money.ToString();
        }
    }

    void DispayCurrentMoney()
    {
        moneyText.text = "Money: " + money.ToString();
    }
}
