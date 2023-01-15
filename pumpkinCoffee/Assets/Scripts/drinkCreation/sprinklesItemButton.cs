using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprinklesItemButton : MonoBehaviour
{
    public drinkMaker drinkMaker;
    public Sprite drinkIngredient;

    void OnMouseDown()
    {
        drinkMaker.activateSprinkles(drinkIngredient);
    }
}
