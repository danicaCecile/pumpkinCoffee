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

    public List<string> day2IntroductionTextMetBefore = new List<string>();
    public List<string> day2IntroductionText = new List<string>();
    public List<string> day2OrderText = new List<string>();
    public GameObject day2YesAndNoButtons;

    public List<string> day2YesText = new List<string>();
    public List<string> day2NoText = new List<string>();

    public GameObject day2NevermindButton;
    public List<string> day2NevermindText = new List<string>();

    public GameObject day2TryAgainButton;
    public List<string> day2TryAgainText = new List<string>();
    void Update()
    {
        if (gameController.getCustomerCount() == 7 && gameController.getDay() == 1 && hasSwappedIsTrixieInside == false)
        {
            isTrixieInside = true;
            hasSwappedIsTrixieInside = true;
        }

        if (gameController.getCustomerCount() == 7 && gameController.getDay() == 1 && gameController.getIsServicingCustomer() == false && hasTrixieEntered == false)
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
                gameController.unPauseDrinkCreationAndSale();
                showBubble();
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
                if (gameController.isDayOver() == false) gameController.getNewCustomer();
            }
        }
    }

    public bool getIsTrixieInside()
    {
        return isTrixieInside;
    }

    private void showBubble()
    {
        trixieBubble.SetActive(true);
    }
}
