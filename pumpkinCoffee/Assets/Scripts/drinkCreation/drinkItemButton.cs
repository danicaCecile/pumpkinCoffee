using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkItemButton : MonoBehaviour
{
    public drinkMaker drinkMaker;
    public Sprite drinkIngredient;
    
    void OnMouseDown()
    {
        drinkMaker.activateDrink(drinkIngredient);
    }
}
