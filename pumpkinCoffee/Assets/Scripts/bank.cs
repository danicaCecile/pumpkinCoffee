using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class bank : MonoBehaviour
{
    private float balance;

    public Image hundreds;
    public Image tens;
    public Image ones;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    public Sprite eight;
    public Sprite nine;
    public Sprite zero;

    public bool canAfford(float price)
    {
        if (price <= balance) return true;
        else return false;
    }

    public void addBal(float money)
    {
        balance += money;
        if(balance > 999f)
        {
            balance = 999f;
        }

        displayBal();
    }

    public void subBal(float money)
    {
            balance -= money;
            displayBal();
    }

    private void displayBal()
    {
        float hundredsAmount = balance / 100f;
        float hundredsDigit = (float)Math.Floor(hundredsAmount);
        float leftOverTens = balance - hundredsDigit*100;

        switch (hundredsDigit)
        {
            case 0:
                hundreds.sprite = zero;
                break;
            case 1:
                hundreds.sprite = one;
                break;
            case 2:
                hundreds.sprite = two;
                break;
            case 3:
                hundreds.sprite = three;
                break;
            case 4:
                hundreds.sprite = four;
                break;
            case 5:
                hundreds.sprite = five;
                break;
            case 6:
                hundreds.sprite = six;
                break;
            case 7:
                hundreds.sprite = seven;
                break;
            case 8:
                hundreds.sprite = eight;
                break;
            case 9:
                hundreds.sprite = nine;
                break;
        }

        float tensAmount = leftOverTens / 10f;
        float tensDigit = (float)Math.Floor(tensAmount);

        switch (tensDigit)
        {
            case 0:
                tens.sprite = zero;
                break;
            case 1:
                tens.sprite = one;
                break;
            case 2:
                tens.sprite = two;
                break;
            case 3:
                tens.sprite = three;
                break;
            case 4:
                tens.sprite = four;
                break;
            case 5:
                tens.sprite = five;
                break;
            case 6:
                tens.sprite = six;
                break;
            case 7:
                tens.sprite = seven;
                break;
            case 8:
                tens.sprite = eight;
                break;
            case 9:
                tens.sprite = nine;
                break;
        }

        float onesDigit = leftOverTens - tensDigit*10;

        switch (onesDigit)
        {
            case 0:
                ones.sprite = zero;
                break;
            case 1:
                ones.sprite = one;
                break;
            case 2:
                ones.sprite = two;
                break;
            case 3:
                ones.sprite = three;
                break;
            case 4:
                ones.sprite = four;
                break;
            case 5:
                ones.sprite = five;
                break;
            case 6:
                ones.sprite = six;
                break;
            case 7:
                ones.sprite = seven;
                break;
            case 8:
                ones.sprite = eight;
                break;
            case 9:
                ones.sprite = nine;
                break;
        }
    }
}
