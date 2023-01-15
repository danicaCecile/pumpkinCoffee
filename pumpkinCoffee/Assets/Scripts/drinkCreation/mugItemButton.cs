using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mugItemButton : MonoBehaviour
{
    public drinkMaker drinkMaker;
    public Sprite drinkIngredient;

    void OnMouseDown()
    {
        drinkMaker.activateMug(drinkIngredient);
    }
}
