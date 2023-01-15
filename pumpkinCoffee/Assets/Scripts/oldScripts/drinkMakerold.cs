using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkMakerold : MonoBehaviour
{
    public List<GameObject> Mugs = new List<GameObject>();
    public List<GameObject> Drinks = new List<GameObject>();
    public List<GameObject> Creams = new List<GameObject>();
    public List<GameObject> Sprinkles = new List<GameObject>();

    private int creationStage = 0;

    private bool addedMug = false;
    private bool addedDrink = false;
    private bool addedCream = false;

    private GameObject currentMug;
    private GameObject currentDrink;
    private GameObject currentCream;
    private GameObject currentSprinkles;

    public void displayMug(GameObject chosenMug)
    {
        foreach (GameObject mug in Mugs)
        {
            if (mug == chosenMug)
            {
                mug.SetActive(true);
                currentMug = mug;
            }
            else
            {
                mug.SetActive(false);
            }
        }
        if (addedMug == false) creationStage = 1;
        addedMug = true;
    }

    public void displayDrink(GameObject chosenDrink)
    {
        if (creationStage >= 1)
        {
            foreach (GameObject drink in Drinks)
            {
                if (drink == chosenDrink)
                {
                    drink.SetActive(true);
                    currentDrink = drink;
                }
                else
                {
                    drink.SetActive(false);
                }
            }
            if (addedDrink == false) creationStage = 2;
            addedDrink = true;
        }
        else
        {
            Debug.Log("Not at drink stage of creation.");
        }
    }

    public void displayCream(GameObject chosenCream)
    {
        if (creationStage >= 2)
        {
            foreach (GameObject cream in Creams)
            {
                if (cream == chosenCream)
                {
                    cream.SetActive(true);
                    currentCream = cream;
                }
                else
                {
                    cream.SetActive(false);
                }
            }
            if (addedCream == false) creationStage = 3;
            addedCream = true;
        }
        else
        {
            Debug.Log("Not at cream stage of creation.");
        }
    }

    public void displaySprinkles(GameObject chosenSprinkles)
    {
        if (creationStage >= 3)
        {
            foreach (GameObject sprinkles in Sprinkles)
            {
                if (sprinkles == chosenSprinkles)
                {
                    sprinkles.SetActive(true);
                    currentSprinkles = sprinkles;
                }
                else
                {
                    sprinkles.SetActive(false);
                }
            }
            creationStage = 4;
        }
        else
        {
            Debug.Log("Not at sprinkles stage of creation.");
        }
    }

    public List<GameObject> getUserDrinkConfig()
    {
        List<GameObject> drinkConfig = new List<GameObject>();

        drinkConfig.Add(currentMug);
        drinkConfig.Add(currentDrink);
        drinkConfig.Add(currentCream);
        drinkConfig.Add(currentSprinkles);

        return drinkConfig;
    }

    public void clearDrink()
    {
        currentMug.SetActive(false);
        currentDrink.SetActive(false);
        currentCream.SetActive(false);
        currentSprinkles.SetActive(false);

        creationStage = 0;
    }

    public int getCreationStage()
    {
        return creationStage;
    }
}
