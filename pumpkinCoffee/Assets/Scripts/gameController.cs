using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public clock Clock;
    public drinkMaker DrinkMaker;
    public drinkSeller DrinkSeller;
    public customer currentCustomer;

    public void pause()
    {
        Clock.pause();
        DrinkMaker.pause();
        DrinkSeller.pause();
    }

    public void unPause()
    {
        Clock.unPause();
        DrinkMaker.unPause();
        DrinkSeller.unPause();
    }

    public void pauseDrinkCreationAndSale()
    {
        DrinkMaker.pause();
        DrinkSeller.pause();

    }

    public void unPauseDrinkCreationAndSale()
    {
        DrinkMaker.unPause();
        DrinkSeller.unPause();
    }

    public bool isDayOver()
    {
        bool clockDayOver = Clock.getIsDayOver();
        bool isServicingCustomer = currentCustomer.getIsServicingCustomer();
        return clockDayOver && !isServicingCustomer;
    }

    public int getDay()
    {
        return Clock.getDay();
    }

    public void resetDay()
    {
        Clock.resetDay();
        currentCustomer.getNewCustomer();
    }
}
