using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public clock Clock;
    public drinkMaker DrinkMaker;
    public drinkSeller DrinkSeller;
    public customer currentCustomer;
    public shopManager shop;
    public checklistManager checklist;
    public endGameManager EndGameManager;
    public dayTransitionManager DayTransitionManager;

    public AudioSource backgroundMusic;

    void Start()
    {
        pause();
        DayTransitionManager.startFirstDay();
    }

    public void startGame()
    {
        currentCustomer.getNewCustomer();
        DrinkSeller.generateDrink();
    }

    public void end()
    {
        EndGameManager.end();
    }

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
        shop.closeShop();
        currentCustomer.getNewCustomer();
    }

    public bool[] getChecklistItems()
    {
        return shop.getChecklistItems();
    }

    public void checkItems()
    {
        checklist.checkItems();
    }

    public void swapBackgroundMusic(AudioClip track)
    {
        backgroundMusic.clip = track;
        backgroundMusic.Play();
    }
}
