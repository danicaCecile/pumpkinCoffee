using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayTransitionManager : MonoBehaviour
{
    public GameObject dayTransitionContainer;
    public GameObject dayOneText;
    public GameObject dayTwoText;
    public GameObject dayThreeText;
    public GameObject partyTimeText;
    public GameObject dayOverText;
    public GameObject checklist;

    public gameController GameController;

    private bool isTransitioning = false;

    private bool hasGameStarted = false;

    void Update()
    {
        if(GameController.isDayOver() == true && isTransitioning == false && hasGameStarted == true)
        {
            isTransitioning = true;
            GameController.pause();
            dayTransitionContainer.SetActive(true);
            StartCoroutine(activateDayTransitionPart1());
        }
    }

    private IEnumerator displayFirstDayText()
    {
        dayTransitionContainer.SetActive(true);
        dayOneText.SetActive(true);

        yield return new WaitForSeconds(3f);

        dayOneText.SetActive(false);
        dayTransitionContainer.SetActive(false);

        GameController.startGame();

        hasGameStarted = true;
        GameController.unPause();
    }

    private IEnumerator activateDayTransitionPart1()
    {
        dayOverText.SetActive(true);

        yield return new WaitForSeconds(3f);

        dayOverText.SetActive(false);
        checklist.SetActive(true);
        GameController.checkItems();
    }

    public void startFirstDay()
    {
        StartCoroutine(displayFirstDayText());
    }

    public bool getHasGameStarted()
    {
        return hasGameStarted;
    }

    public void startNextDay()
    {
        StartCoroutine(activateDayTransitionPart2());
    }

    private IEnumerator activateDayTransitionPart2()
    {
        checklist.SetActive(false);
        activateDayTransitionText(true);

        yield return new WaitForSeconds(3f);

        activateDayTransitionText(false);
        dayTransitionContainer.SetActive(false);

        if (GameController.getDay() == 2) GameController.end();
        else
        {
            GameController.unPause();
            GameController.resetDay();
            isTransitioning = false;
        }
    }

    private void activateDayTransitionText(bool activate)
    {
        int currentDay = GameController.getDay();
        if(currentDay == 0)
        {
            dayTwoText.SetActive(activate);
        }
        else if(currentDay == 1)
        {
            dayThreeText.SetActive(activate);
        }
        else
        {
            partyTimeText.SetActive(activate);
        }
    }
 }
