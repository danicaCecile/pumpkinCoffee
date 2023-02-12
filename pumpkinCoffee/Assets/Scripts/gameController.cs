using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public clock Clock;
    public drinkMaker DrinkMaker;
    public drinkSeller DrinkSeller;

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

}
