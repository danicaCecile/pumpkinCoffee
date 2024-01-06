using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class drinkSeller : MonoBehaviour
{
    public drinkMaker userDrink;

    public GameObject mug;
    public GameObject drink;
    public GameObject cream;
    public GameObject sprinkles;

    public TextMeshProUGUI mugTextBox;
    public TextMeshProUGUI drinkTextBox;
    public TextMeshProUGUI creamTextBox;
    public TextMeshProUGUI sprinklesTextBox;
    public GameObject textBoxObject;

    public AudioSource bellDing;

    public List<Sprite> mugOptions = new List<Sprite>();
    public List<Sprite> drinkOptions = new List<Sprite>();
    public List<Sprite> creamOptions = new List<Sprite>();
    public List<Sprite> sprinklesOptions = new List<Sprite>();

    public List<string> mugOptionsText = new List<string>();
    public List<string> drinkOptionsText = new List<string>();
    public List<string> creamOptionsText = new List<string>();
    public List<string> sprinklesOptionsText = new List<string>();

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

    private int rand = 0;

    private int drinkChoice = 0;
    private int mugChoice = 0;
    private int creamChoice = 0;
    private int sprinklesChoice = 0;

    public void generateDrink()
    {
        Debug.Log(GameController.isPicPrompt);
        customerDrinkConfig.Clear();
        rand = Random.Range(0, 3);
        mugChoice = rand;
        Sprite chosenMug = mugOptions[rand];
        customerDrinkConfig.Add(chosenMug);

        if(GameController.isPicPrompt == true) {
            mug.SetActive(true);
            mug.GetComponent<SpriteRenderer>().sprite = chosenMug;
        }
        else {
            textBoxObject.SetActive(true);
            mugTextBox.text = mugOptionsText[rand];
        }

        rand = Random.Range(0, 3);
        drinkChoice = rand;
        Sprite chosenDrink = drinkOptions[rand];
        customerDrinkConfig.Add(chosenDrink);

        if(GameController.isPicPrompt == true) {
            drink.SetActive(true);
            drink.GetComponent<SpriteRenderer>().sprite = chosenDrink;
        }
        else drinkTextBox.text = drinkOptionsText[rand];

        rand = Random.Range(0, 3);
        creamChoice = rand;
        Sprite chosenCream = creamOptions[rand];
        customerDrinkConfig.Add(chosenCream);

        if(GameController.isPicPrompt == true) {
            cream.SetActive(true);
            cream.GetComponent<SpriteRenderer>().sprite = chosenCream;
        }
        else creamTextBox.text = creamOptionsText[rand];

        rand = Random.Range(0, 3);
        sprinklesChoice = rand;
        Sprite chosenSprinkles = sprinklesOptions[rand];
        customerDrinkConfig.Add(chosenSprinkles);

        if(GameController.isPicPrompt == true) {
            sprinkles.SetActive(true);
            sprinkles.GetComponent<SpriteRenderer>().sprite = chosenSprinkles;
        }
        else sprinklesTextBox.text = sprinklesOptionsText[rand];
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
        textBoxObject.SetActive(false);
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

    public void swapToPicture(){
        textBoxObject.SetActive(false);
        mug.SetActive(true);
        drink.SetActive(true);
        cream.SetActive(true);
        sprinkles.SetActive(true);

        mug.GetComponent<SpriteRenderer>().sprite = mugOptions[mugChoice];
        drink.GetComponent<SpriteRenderer>().sprite = drinkOptions[drinkChoice];
        cream.GetComponent<SpriteRenderer>().sprite = creamOptions[creamChoice];
        sprinkles.GetComponent<SpriteRenderer>().sprite = sprinklesOptions[sprinklesChoice];
    }

    public void swapToText(){
        mug.SetActive(false);
        drink.SetActive(false);
        cream.SetActive(false);
        sprinkles.SetActive(false);
        textBoxObject.SetActive(true);

        mugTextBox.text = mugOptionsText[mugChoice];
        drinkTextBox.text = drinkOptionsText[drinkChoice];
        creamTextBox.text = creamOptionsText[creamChoice];
        sprinklesTextBox.text = sprinklesOptionsText[sprinklesChoice];
    }
}
