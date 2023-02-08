using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkSeller : MonoBehaviour
{
    public drinkMaker userDrink;

    public GameObject mug;
    public GameObject drink;
    public GameObject cream;
    public GameObject sprinkles;
    
    public List<Sprite> mugOptions = new List<Sprite>();
    public List<Sprite> drinkOptions = new List<Sprite>();
    public List<Sprite> creamOptions = new List<Sprite>();
    public List<Sprite> sprinklesOptions = new List<Sprite>();

    private List<Sprite> customerDrinkConfig = new List<Sprite>();

    public customer currentCustomer;
    public bank bank;

    void Start()
    {
        generateDrink();
    }

    public void generateDrink()
    {
        int rand = Random.Range(0, 3);
        mug.SetActive(true);
        Sprite chosenMug = mugOptions[rand];
        mug.GetComponent<SpriteRenderer>().sprite = chosenMug;
        customerDrinkConfig.Add(chosenMug);

        rand = Random.Range(0, 3);
        drink.SetActive(true);
        Sprite chosenDrink = drinkOptions[rand];
        drink.GetComponent<SpriteRenderer>().sprite = chosenDrink;
        customerDrinkConfig.Add(chosenDrink);

        rand = Random.Range(0, 3);
        cream.SetActive(true);
        Sprite chosenCream = creamOptions[rand];
        cream.GetComponent<SpriteRenderer>().sprite = chosenCream;
        customerDrinkConfig.Add(chosenCream);

        rand = Random.Range(0, 3);
        sprinkles.SetActive(true);
        Sprite chosenSprinkles = sprinklesOptions[rand];
        sprinkles.GetComponent<SpriteRenderer>().sprite = chosenSprinkles;
        customerDrinkConfig.Add(chosenSprinkles);
    }

    public void clearDrink()
    {
        customerDrinkConfig.Clear();

        mug.SetActive(false);
        drink.SetActive(false);
        cream.SetActive(false);
        sprinkles.SetActive(false);
    }

    public bool isCorrectDrink()
    {
        List<Sprite> userDrinkConfig = userDrink.getConfig();

        if (userDrinkConfig.Count < 4) return false;
        int correctIngredients = 0;

        int i = 0;
        foreach (Sprite userIngredient in userDrinkConfig)
        {
            Sprite customerIngredient = customerDrinkConfig[i];
            if (customerIngredient == userIngredient) correctIngredients++;
            i++;
        }

        Debug.Log(correctIngredients);
        if (correctIngredients == 4) return true;
        else return false;
    }

    private IEnumerator bellPressedAction()
    {
        bool didWin = isCorrectDrink();
        if (didWin == true)
        {
            bank.addBal(5f);
        }

        clearDrink();

        userDrink.clearDrink();
        currentCustomer.emote(didWin);

        yield return new WaitForSeconds(1f);

        currentCustomer.hideBubble();
        currentCustomer.customerLeave();
        generateDrink();
    }

    void OnMouseDown()
    {
        StartCoroutine(bellPressedAction());
    }
}
