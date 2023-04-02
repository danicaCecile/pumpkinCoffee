using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trixieController : MonoBehaviour
{
    public GameObject trixie;
    public GameObject trixieWindow;
    public GameObject trixieApproaching0;
    public GameObject trixieApproaching1;
    public GameObject trixieApproaching2;

    public gameController GameController;

    private bool hasApproached0 = false;
    private bool hasApproached1 = false;
    private bool hasApproached2 = false;
    private bool hasApproached3 = false;

    private bool isTalkingToTrixie = false;
    private bool isTrixieMoving = false;
    private bool isTrixieAtWindow = false;
    private bool isTrixieLeaving = false;
    private bool isTrixieArriving = false;

    public float speed = 0.1f;

    public GameObject textBubble;

    public GameObject textSpace;
    public GameObject introductionArrowButton;
    public TextMeshProUGUI text;

    public GameObject yesAndNoButtons;
    public bool answer;

    public List<string> introductionText = new List<string>();
    private int currentTextCounter = 0;
    private string currentText = null;

    public List<string> yesText = new List<string>();

    public List<string> noText = new List<string>();

    public SpriteRenderer trixieRender;
    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite neutralFace;
    public GameObject happyHeart;
    public GameObject sadSquiggle;
    public Animator blinkAnimator;

    public GameObject yesArrow;
    public GameObject noArrow;
    public GameObject nevermind;

    private bool readyForDrink = false; 

    void Update()
    {
        if (GameController.getDay() == 0)
        {
            if (GameController.getCustomerCount() == 3 && hasApproached0 == false)
            {
                trixieApproaching0.SetActive(true);
                hasApproached0 = true;
            }

            if (GameController.getCustomerCount() == 5 && hasApproached1 == false)
            {
                trixieApproaching1.SetActive(true);
                hasApproached1 = true;
            }

            if (GameController.getCustomerCount() == 7 && hasApproached2 == false)
            {
                isTrixieAtWindow = true;
                trixieApproaching2.SetActive(true);
                hasApproached2 = true;
            }

            if (GameController.getCustomerCount() == 7 && hasApproached3 == false && GameController.getIsServicingCustomer() == false)
            {
                isTrixieArriving = true;
                hasApproached3 = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(isTrixieArriving == true)
        {
            trixieWindow.transform.position += new Vector3(0, speed, 0);
            if (trixieWindow.transform.position.y >= 1.7f)
            {
                isTrixieArriving = false;
                StartCoroutine(displayFirstWindowBubble());
            }
        }

        if (isTrixieLeaving == true)
        {
            trixieWindow.transform.position += new Vector3(0, -speed, 0);
            if (trixieWindow.transform.position.y <= 0.5f)
            {
                GameController.getNewCustomer();
                isTrixieLeaving = false;
                isTrixieAtWindow = false;
            }
        }
    }

    public bool getIsTrixieAtWindow()
    {
        return isTrixieAtWindow;
    }

    private IEnumerator displayFirstWindowBubble()
    {
        yield return new WaitForSeconds(0.2f);
        textBubble.SetActive(true);
        currentText = introductionText[0];
        text.SetText(currentText);
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

    public void displayIntroductionText()
    {
        bool isOption = displayText(introductionText);
        if(isOption == true)
        {
            introductionArrowButton.SetActive(false);
            textSpace.SetActive(false);
            yesAndNoButtons.SetActive(true);
        }
    }

    public void yes()
    {
        yesAndNoButtons.SetActive(false);
        yesArrow.SetActive(true);
        switchToEmote(happyFace);
        happyHeart.SetActive(true);
    }

    public void no()
    {
        textSpace.SetActive(false);
        nevermind.SetActive(false);
        yesAndNoButtons.SetActive(false);
        noArrow.SetActive(true);
        switchToEmote(sadFace);
        sadSquiggle.SetActive(true);
        currentTextCounter = -1;
        readyForDrink = false;
    }

    public void displayYesText()
    {
        switchToNeutral();
        textSpace.SetActive(true);
        currentText = yesText[0];
        text.SetText(currentText);
        yesArrow.SetActive(false);
        happyHeart.SetActive(false);
        nevermind.SetActive(true);
        readyForDrink = true;
    }

    public void displayNoText()
    {
        switchToNeutral();
        textSpace.SetActive(true);
       
        sadSquiggle.SetActive(false);

        bool isOption = displayText(noText);
        if(isOption == true)
        {
            triggerLeave();
        }
    }

    public void triggerLeave()
    {
        isTrixieLeaving = true;
        textBubble.SetActive(false);
    }
 }
