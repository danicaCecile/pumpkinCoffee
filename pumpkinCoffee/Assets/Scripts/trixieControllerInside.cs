using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trixieControllerInside : MonoBehaviour
{
    public GameObject trixie;
    private bool trixieEntering = false;
    private bool trixieLeaving = false;
    private bool isServicingTrixie;
    public gameController gameController;
    public float speed = 0.07f;
    public AudioSource doorBell;
    public GameObject trixieBubble;
    private bool hasTrixieEntered = false;
    private bool hasSwappedIsTrixieInside = false;
    private bool isTrixieInside = false;
    public bool isReadyForDrink = false;

    public List<string> day2IntroductionTextMetBefore = new List<string>();
    public List<string> day2IntroductionText = new List<string>();

    public List<string> day2OrderText = new List<string>();
    public GameObject day2YesAndNoButtons;
    public GameObject day2YesArrowButton;

    public GameObject day2YesArrow2Button;
    public GameObject day2NoArrowButton;
    //public GameObject day2NoArrow2Button;

    public GameObject day2IntroductionArrowButton;

    public List<string> day2YesText = new List<string>();
    public List<string> day2NoText = new List<string>();

    public GameObject day2NevermindButton;
    public List<string> day2NevermindText = new List<string>();

    public GameObject day2TryAgainButton;
    public List<string> day2TryAgainText = new List<string>();

    public List<string> day2OneIngredientText = new List<string>();
    public List<string> day2TwoIngredientText = new List<string>();

    public GameObject textSpace;
    public TextMeshProUGUI text;
    private int currentTextCounter = 0;
    private string currentText = null;

    public Animator blinkAnimator;
    public SpriteRenderer trixieRender;
    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite neutralFace;
    public GameObject happyHeart;
    public GameObject sadSquiggle;

    public GameObject oneCorrectButton0;
    public GameObject oneCorrectButton1;
    public GameObject twoCorrectButton0;
    public GameObject twoCorrectButton1;


    public List<string> oneCorrectText = new List<string>();
    public List<string> twoCorrectText = new List<string>();
    public List<string> twoCorrectTextMetBefore = new List<string>();
    public GameObject Day2Container;

    public GameObject day3IntroductionArrowButton;
    public GameObject day3YesAndNoButtons;
    public List<string> day3IntroductionTextMetBefore = new List<string>();
    public List<string> day3IntroductionText = new List<string>();
    public GameObject day3YesArrowButton;
    public GameObject day3NoArrowButton;
    public GameObject day3NevermindButton;
    public List<string> day3YesText = new List<string>();
    public GameObject day3YesArrow2Button;
    public List<string> day3OrderText = new List<string>();
    public List<string> day3NoText = new List<string>();
    public GameObject tryAgainFavoriteButton;
    public List<string> day3TryAgainText = new List<string>();
    public GameObject correctFavoriteButton0;
    public GameObject correctFavoriteButton1;

    private bool gotCraft = false;
    void Update()
    {
        if (gameController.getCustomerCount() == 7 && gameController.getDay() == 1 && hasSwappedIsTrixieInside == false)
        {
            hasSwappedIsTrixieInside = true;
            isTrixieInside = true;
        }

        if (gameController.getCustomerCount() == 7 && gameController.getDay() == 1 && gameController.getIsServicingCustomer() == false && hasTrixieEntered == false)
        {
            gameController.pauseDrinkCreationAndSale();
            trixieEntering = true;
            hasTrixieEntered = true;
        }

        if (gameController.getCustomerCount() == 7 && gameController.getDay() == 2 && hasSwappedIsTrixieInside == false)
        {
            hasSwappedIsTrixieInside = true;
            trixie.SetActive(false);
            isTrixieInside = true;
        }

        if (gameController.getCustomerCount() == 7 && gameController.getDay() == 2 && gameController.getIsServicingCustomer() == false && hasTrixieEntered == false)
        {
            gameController.pauseDrinkCreationAndSale();
            trixieEntering = true;
            hasTrixieEntered = true;
        }
    }
    void FixedUpdate()
    {
        if (trixieEntering == true)
        {
            trixie.SetActive(true);
            trixie.transform.position += new Vector3(speed * -1, 0, 0);
            if (trixie.transform.position.x <= 2.6f)
            {
                trixieEntering = false;
                //isTrixieInside = true;
                gameController.unPauseDrinkCreationAndSale();
                showBubble();
                if(gameController.getDay() == 2) {
                    currentTextCounter = -1;
                    day3DisplayIntroductionText();
                    day3IntroductionArrowButton.SetActive(true);
                    Day2Container.SetActive(false);
                }
            }
        }

        if (trixieLeaving == true)
        {
            trixie.transform.position += new Vector3(speed, 0, 0);
            if (trixie.transform.position.x >= 5f)
            {
                trixieLeaving = false;
                isServicingTrixie = false;
                gameController.unPauseDrinkCreationAndSale();
                trixie.SetActive(false);
                isTrixieInside = false;
                gameController.addTrixieInteraction();
                if (gameController.isDayOver() == false) gameController.getNewCustomer();
            }
        }
    }

    public void resetInsideTrixie(){
        hasSwappedIsTrixieInside = false;
        hasTrixieEntered = false;
    }

    private void switchToEmote(Sprite emote)
    {
        blinkAnimator.enabled = false;
        trixieRender.sprite = emote;
    }

    private void switchToNeutral()
    {
        blinkAnimator.enabled = true;
        trixieRender.sprite = neutralFace;
    }

    public bool getIsTrixieInside()
    {
        return isTrixieInside;
    }

    public bool getIsReadyForDrink(){
        return isReadyForDrink;
    }
    private void showBubble()
    {
        trixieBubble.SetActive(true);
        if (gameController.getTrixieInteractions() >= 1) text.SetText(day2IntroductionTextMetBefore[0]);
        else text.SetText(day2IntroductionText[0]);
    }

    public void day2DisplayIntroductionText()
    {
        List<string> introductionText = null;
        if (gameController.getTrixieInteractions() >= 1) introductionText = day2IntroductionTextMetBefore;
        else introductionText = day2IntroductionText;
        bool isOption = displayText(introductionText);
        if (isOption == true)
        {
            day2IntroductionArrowButton.SetActive(false);
            textSpace.SetActive(false);
            day2YesAndNoButtons.SetActive(true);
        }
    }

    public void day2Yes()
    {
        day2YesArrowButton.SetActive(true);
        textSpace.SetActive(false);

        day2YesAndNoButtons.SetActive(false);
        switchToEmote(happyFace);
        happyHeart.SetActive(true);
    }

    public void day2DisplayYesText(){
        switchToNeutral();
        textSpace.SetActive(true);
        text.SetText(day2YesText[0]);
        happyHeart.SetActive(false);
        day2YesArrowButton.SetActive(false);
        day2YesArrow2Button.SetActive(true);
    }

    public void day2Order()
    {
        text.SetText(day2OrderText[0]);
        day2YesArrow2Button.SetActive(false);
        tryAgainHeartButton.SetActive(false);
        day2NevermindButton.SetActive(true);
        isReadyForDrink = true;
    }

    public void day2No()
    {
        day2NoArrowButton.SetActive(true);
        sadSquiggle.SetActive(true);
        day2NevermindButton.SetActive(false);
        switchToEmote(sadFace);
        textSpace.SetActive(false);
        day2YesAndNoButtons.SetActive(false);
        currentTextCounter = -1;
        isReadyForDrink = false;
    }

    public void displayNoText(){
        textSpace.SetActive(true);
        switchToNeutral();
        sadSquiggle.SetActive(false);
        bool isOption = displayText(day2NoText);
        if(isOption == true)
        {
            triggerLeave();
        }
    }

    public void oneCorrectIngredient0()
    {
        isReadyForDrink = false;
        currentTextCounter = -1;
        textSpace.SetActive(false);
        switchToEmote(happyFace);
        oneCorrectButton0.SetActive(true);
        happyHeart.SetActive(true);
        day2NevermindButton.SetActive(false);
        Debug.Log("one correct ingredient");
    }

    public void oneCorrectIngredient1()
    {
        textSpace.SetActive(true);
        switchToNeutral();
        happyHeart.SetActive(false);
        oneCorrectButton0.SetActive(false);
        oneCorrectButton1.SetActive(true);
        displayText(oneCorrectText);
    }

    public void twoCorrectIngredient0(){
        isReadyForDrink = false;
        currentTextCounter = -1;
        textSpace.SetActive(false);
        switchToEmote(happyFace);
        twoCorrectButton0.SetActive(true);
        happyHeart.SetActive(true);
        day2NevermindButton.SetActive(false);
        Debug.Log("two correct ingredients");
    }

    private int optionCounter = 0;
    public GameObject craftButtons;

    public void twoCorrectIngredient1(){
        textSpace.SetActive(true);
        switchToNeutral();
        happyHeart.SetActive(false);
        twoCorrectButton0.SetActive(false);
        twoCorrectButton1.SetActive(true);

        gotCraft = true;
        bool isOption;
        if(gameController.getCraftChoice() != -1) isOption = displayText(twoCorrectTextMetBefore);
        else isOption = displayText(twoCorrectText);

        if (isOption == true)
        {
            if (optionCounter == 0)
            {
                activateCraftButtons();
                textSpace.SetActive(false);
                twoCorrectButton1.SetActive(false);
            }
            else triggerLeave();
            optionCounter++;
        }
    }

    public GameObject buntingButton;
    public GameObject artButton;
    public GameObject shelfButton;
    public GameObject bunting;
    public GameObject art;
    public GameObject shelfObject;

    private void activateCraftButtons(){
        Debug.Log(gameController.getCraftChoice());
        craftButtons.SetActive(true);
        int choice = gameController.getCraftChoice();
        if(choice == 0) buntingButton.SetActive(false);
        else if(choice == 1) shelfButton.SetActive(false);
        else if(choice == 2) artButton.SetActive(false);
    }

    public void chooseBunting()
    {
        gameController.showBunting(bunting);
        if(gameController.getDay() == 1) twoCorrectIngredient1();
        else correctFavorite1();
        buntingButton.SetActive(false);
        craftButtons.SetActive(false);
    }

    public void chooseShelfObject()
    {
        gameController.showShelfObject(shelfObject);
        if(gameController.getDay() == 1) twoCorrectIngredient1();
        else correctFavorite1();
        shelfButton.SetActive(false);
        craftButtons.SetActive(false);
    }

    public void chooseWallArt()
    {
        gameController.showWallArt(art);
        if(gameController.getDay() == 1) twoCorrectIngredient1();
        else correctFavorite1();
        artButton.SetActive(false);
        craftButtons.SetActive(false);
    }

    public GameObject tryAgainHeartButton;
    public void tryAgainHeart(){
        isReadyForDrink = false;
        day2NevermindButton.SetActive(false);
        tryAgainHeartButton.SetActive(true);
        currentTextCounter = -1;
        displayText(day2TryAgainText);
    }

    public void triggerLeave()
    {
        trixieLeaving = true;
        trixieBubble.SetActive(false);
    }

    private void nextTextOption(List<string> t)
    {
        currentTextCounter++;
        currentText = t[currentTextCounter];
    }

    private bool displayText(List<string> t)
    {
        nextTextOption(t);
        if (currentText != "option")
        {
            text.SetText(currentText);
            return false;
        }
        else return true;
    }

    //Day 3
    public void day3DisplayIntroductionText()
    {
        List<string> introductionText = null;
        if (gameController.getTrixieInteractions() >= 1) introductionText = day3IntroductionTextMetBefore;
        else introductionText = day3IntroductionText;
        bool isOption = displayText(introductionText);
        if (isOption == true)
        {
            day3IntroductionArrowButton.SetActive(false);
            textSpace.SetActive(false);
            day3YesAndNoButtons.SetActive(true);
        }
    }

    public void day3Yes()
    {
        day3YesArrowButton.SetActive(true);
        textSpace.SetActive(false);

        day3YesAndNoButtons.SetActive(false);
        switchToEmote(happyFace);
        happyHeart.SetActive(true);
    }

    public void day3DisplayYesText(){
        switchToNeutral();
        textSpace.SetActive(true);
        text.SetText(day3YesText[0]);
        happyHeart.SetActive(false);
        day3YesArrowButton.SetActive(false);
        day3YesArrow2Button.SetActive(true);
    }

    public void day3Order()
    {
        tryAgainFavoriteButton.SetActive(false);
        text.SetText(day3OrderText[0]);
        day3YesArrow2Button.SetActive(false);
        day3NevermindButton.SetActive(true);
        isReadyForDrink = true;
    }

    public void day3No()
    {
        day3NoArrowButton.SetActive(true);
        sadSquiggle.SetActive(true);
        day3NevermindButton.SetActive(false);
        switchToEmote(sadFace);
        textSpace.SetActive(false);
        day3YesAndNoButtons.SetActive(false);
        currentTextCounter = -1;
        isReadyForDrink = false;
    }

    public void day3DisplayNoText(){
        textSpace.SetActive(true);
        switchToNeutral();
        sadSquiggle.SetActive(false);
        bool isOption = displayText(day3NoText);
        if(isOption == true)
        {
            triggerLeave();
        }
    }

    public void correctFavorite(){
        isReadyForDrink = false;
        currentTextCounter = -1;
        textSpace.SetActive(false);
        switchToEmote(happyFace);
        correctFavoriteButton0.SetActive(true);
        happyHeart.SetActive(true);
        day3NevermindButton.SetActive(false);
        optionCounter = 0;
    }

    public void correctFavorite1(){
        textSpace.SetActive(true);
        switchToNeutral();
        happyHeart.SetActive(false);
        correctFavoriteButton0.SetActive(false);
        correctFavoriteButton1.SetActive(true);

        bool isOption;
        if(gotCraft == true) isOption = displayText(twoCorrectTextMetBefore);
        else isOption = displayText(twoCorrectText);

        if (isOption == true)
        {
            if (optionCounter == 0)
            {
                activateCraftButtons();
                textSpace.SetActive(false);
                correctFavoriteButton1.SetActive(false);
            }
            else triggerLeave();
            optionCounter++;
        }
    }
    
    public void tryAgainFavorite(){
        isReadyForDrink = false;
        day3NevermindButton.SetActive(false);
        tryAgainFavoriteButton.SetActive(true);
        currentTextCounter = -1;
        displayText(day3TryAgainText);
    }
}
