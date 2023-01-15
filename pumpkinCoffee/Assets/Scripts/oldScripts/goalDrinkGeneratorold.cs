using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalDrinkGenerator : MonoBehaviour
{
    public List<GameObject> Mugs = new List<GameObject>();
    public List<GameObject> Drinks = new List<GameObject>();
    public List<GameObject> Creams = new List<GameObject>();
    public List<GameObject> Sprinkles = new List<GameObject>();

    private List<GameObject> drinkConfig = new List<GameObject>();

    private GameObject currentMug;
    private GameObject currentDrink;
    private GameObject currentCream;
    private GameObject currentSprinkles;

    void Start()
    {
        generateGoalDrink();
    }

    private void generateGoalDrink()
    {
        int randMug = Random.Range(0, Mugs.Count);
        int randDrink = Random.Range(0, Drinks.Count);
        int randCream = Random.Range(0, Creams.Count);
        int randSprinkles = Random.Range(0, Sprinkles.Count);

        currentMug = Mugs[randMug];
        currentMug.SetActive(true);
        drinkConfig.Add(currentMug);

        currentDrink = Drinks[randDrink];
        currentDrink.SetActive(true);
        drinkConfig.Add(currentDrink);

        currentCream = Creams[randCream];
        currentCream.SetActive(true);
        drinkConfig.Add(currentCream);

        currentSprinkles = Sprinkles[randSprinkles];
        currentSprinkles.SetActive(true);
        drinkConfig.Add(currentSprinkles);
    }

    public List<GameObject> getDrinkConfig()
    {
        return drinkConfig;
    }

    public void clearDrink()
    {
        currentMug.SetActive(false);
        currentDrink.SetActive(false);
        currentCream.SetActive(false);
        currentSprinkles.SetActive(false);

        drinkConfig.Clear();
    }
}
