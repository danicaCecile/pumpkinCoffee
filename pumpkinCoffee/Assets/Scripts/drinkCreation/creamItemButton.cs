using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creamItemButton : MonoBehaviour
{
    public drinkMaker drinkMaker;
    public Sprite drinkIngredient;

    void OnMouseDown()
    {
        drinkMaker.activateCream(drinkIngredient);
    }
}
