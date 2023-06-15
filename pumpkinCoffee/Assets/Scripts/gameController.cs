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
    public trixieController Trixie;
    public trixieControllerInside trixieInside;
    public AudioSource backgroundMusic;

    private int trixieDrinkStage = 0;

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
        bool isTrixieActuallyAtWindow = Trixie.getIsTrixieActuallyAtWindow();
        return clockDayOver && !isServicingCustomer && !isTrixieActuallyAtWindow;
    }

    public bool isTimeUp()
    {
        return Clock.getIsDayOver();
    }

    public bool getIsServicingCustomer()
    {
        return currentCustomer.getIsServicingCustomer();
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

    public void getNewCustomer()
    {
        if (Clock.getIsDayOver() == false)
        {
            currentCustomer.getNewCustomer();
            DrinkSeller.generateDrink();
        }
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

    public bool didWin()
    {
        return EndGameManager.didWin();
    }

    public int getCustomerCount()
    {
        return currentCustomer.getCustomerCount();
    }

    public void resetCustomerCount()
    {
        currentCustomer.resetCustomerCount();
    }
    
    public bool getIsTrixieAtWindow()
    {
        return Trixie.getIsTrixieAtWindow();
    }

    public bool getIsTrixieInside()
    {
        return trixieInside.getIsTrixieInside();
    }
    public bool getIsTrixieReady()
    {
        return Trixie.getReadyForDrink();
    }

    public void nextTrixieDrinkStage()
    {
        trixieDrinkStage++;
    }

    public int getTrixieDrinkStage()
    {
        return trixieDrinkStage;
    }

    public void tryAgainPumpkin()
    {
        if(getIsTrixieAtWindow() == true)
        {
            Trixie.tryAgainPumpkinDrink();
        }
    }

    public void oneCorrectPumpkin()
    {
        Trixie.oneCorrectIngredient0();
    }

    public void twoCorrectPumpkin()
    {
        Trixie.twoCorrectIngredient0();
    }

    public void showBunting(GameObject option)
    {
        shop.showBunting(option, 00);
    }

    public void showWallArt(GameObject option)
    {
        shop.showWallArt(option, 00);
    }

    public void showShelfObject(GameObject option)
    {
        shop.showShelfObject(option, 00);
    }
}
