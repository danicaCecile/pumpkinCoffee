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

    public AudioSource bellDing;

    public List<Sprite> mugOptions = new List<Sprite>();
    public List<Sprite> drinkOptions = new List<Sprite>();
    public List<Sprite> creamOptions = new List<Sprite>();
    public List<Sprite> sprinklesOptions = new List<Sprite>();

    private List<Sprite> customerDrinkConfig = new List<Sprite>();

    public customer currentCustomer;
    public bank bank;
    public gameController GameController;

    public float drinkCost = 10f;

    private bool isPaused = false;

    public Sprite up;
    public Sprite down;
    public SpriteRenderer bell;
    private Sprite chosenMug;
    public void generateDrink()
    {
        //Debug.Log("Generate!");
        customerDrinkConfig.Clear();
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

    private int isPumpkinDrink()
    {
        List<Sprite> userDrinkConfig = userDrink.getConfig();
        int correctIngredients = 0;

        if (userDrinkConfig.Count < 4) return -1;
        if (userDrinkConfig[0] == mugOptions[2]) correctIngredients++;
        if (userDrinkConfig[1] == drinkOptions[2] || userDrinkConfig[2] == creamOptions[1]) correctIngredients++;

        return correctIngredients;
    }

    private int isHeartDrink()
    {
        List<Sprite> userDrinkConfig = userDrink.getConfig();
        int correctIngredients = 0;

        if (userDrinkConfig.Count < 4) return -1;
        if (userDrinkConfig[0] == mugOptions[0]) correctIngredients++;
        if (userDrinkConfig[1] == drinkOptions[1] || userDrinkConfig[3] == sprinklesOptions[1]) correctIngredients++;

        return correctIngredients;
    }

    private Sprite isFavoriteDrink()
    {
        List<Sprite> userDrinkConfig = userDrink.getConfig();
        if (userDrinkConfig.Count < 2) return null;
        else return userDrinkConfig[0];
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
        //Debug.Log(GameController.getIsTrixieReady());
        //Debug.Log(GameController.getTrixieDrinkStage());
        //Debug.Log(customerDrinkConfig[0]);
        if (isPaused == false)
        {
            if(GameController.getIsTrixieReady() == true)
            {
                if(GameController.getDay() == 0){
                    //compare to pumpkin drink
                    if (isPumpkinDrink() == -1)
                    {
                        GameController.tryAgainPumpkin();
                    }
                    else if (isPumpkinDrink() == 0) GameController.tryAgainPumpkin();
                    else if (isPumpkinDrink() == 1)
                    {
                        bank.addBal(drinkCost);
                        GameController.oneCorrectPumpkin();
                    }//could be better
                    else if (isPumpkinDrink() == 2)
                    {
                        bank.addBal(drinkCost);
                        GameController.twoCorrectPumpkin();
                    }//perfect
                }
                else if(GameController.getDay() == 1)
                {
                    //compare to heart drink
                    Debug.Log("Activated!");
                    if (isHeartDrink() == -1) GameController.tryAgainHeart();
                    else if(isHeartDrink() == 0) GameController.tryAgainHeart();
                    else if (isHeartDrink() == 1) {
                        GameController.oneCorrectHeart();
                        bank.addBal(drinkCost); //could be better
                    }
                    else if (isHeartDrink() == 2) {
                        GameController.twoCorrectHeart();
                        bank.addBal(drinkCost); //perfect
                    }
                }
                else
                {
                    //make her your favorite drink (only condition is that it has to have a mug and a drink)
                    chosenMug = isFavoriteDrink();
                    if (chosenMug == null) GameController.tryAgainFavorite();
                    else {
                        GameController.correctFavorite();
                        bank.addBal(drinkCost);
                    }
                }

                clearDrink();
                userDrink.clearDrink();
                generateDrink();
            }
            else
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
    }

    public string getChosenMug(){
        if(chosenMug == mugOptions[0]) return "heart";
        if(chosenMug == mugOptions[1]) return "lace";
        if(chosenMug == mugOptions[2]) return "pumpkin";
        return "";
    }

    private IEnumerator bellAnimation()
    {
        bellDing.Play();
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
