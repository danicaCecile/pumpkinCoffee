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

    public float speed = 0.07f;

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
    void Start()
    {
        
    }

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
                isTrixieMoving = true;
                hasApproached3 = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(isTrixieMoving == true)
        {
            trixieWindow.transform.position += new Vector3(0, speed, 0);
            if (trixieWindow.transform.position.y >= 1.7f)
            {
                isTrixieMoving = false;
                StartCoroutine(displayFirstWindowBubble());
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
        textSpace.SetActive(true);
        yesAndNoButtons.SetActive(false);
        currentText = yesText[0];
        text.SetText(currentText);
        currentTextCounter = 0;
    }

    public void no()
    {
        textSpace.SetActive(true);
        yesAndNoButtons.SetActive(false);
        currentText = noText[0];
        text.SetText(currentText);
        currentTextCounter = 0;
    }

    public void displayYesText()
    {
        displayText(yesText);
    }

    public void displayNoText()
    {
        displayText(noText);
    }
}
