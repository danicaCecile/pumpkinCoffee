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

    public float drinkCost = 10f;

    private bool isPaused = false;

    public Sprite up;
    public Sprite down;
    public SpriteRenderer bell;

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

    private bool isCorrectDrink()
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

        if (correctIngredients == 4) return true;
        else return false;
    }

    private IEnumerator bellPressedAction()
    {
        if(isPaused == false)
        {
            bool didWin = isCorrectDrink();
            if (didWin == true)
            {
                bank.addBal(drinkCost);
            }

            clearDrink();

            userDrink.clearDrink();
            currentCustomer.emote(didWin);

            yield return new WaitForSeconds(1f);

            currentCustomer.hideBubble();
            currentCustomer.customerLeave();
            generateDrink();
        }
    }

    private IEnumerator bellAnimation()
    {
        bell.sprite = down;

        yield return new WaitForSeconds(0.5f);

        bell.sprite = up;
    }

    void OnMouseDown()
    {
        StartCoroutine(bellPressedAction());
        StartCoroutine(bellAnimation());
    }

    public void pause()
    {
        isPaused = true;
    }

    public void unPause()
    {
        isPaused = false;
    }
}
