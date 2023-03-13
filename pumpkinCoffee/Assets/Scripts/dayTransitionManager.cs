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

    void Update()
    {
        if(GameController.isDayOver() == true && isTransitioning == false)
        {
            isTransitioning = true;
            GameController.pause();
            dayTransitionContainer.SetActive(true);
            StartCoroutine(activateDayTransition());
        }
    }

    private IEnumerator activateDayTransition()
    {
        dayOverText.SetActive(true);

        yield return new WaitForSeconds(2f);

        dayOverText.SetActive(false);
        checklist.SetActive(true);

        yield return new WaitForSeconds(2f);

        checklist.SetActive(false);
        activateDayTransitionText(true);

        yield return new WaitForSeconds(2f);

        activateDayTransitionText(false);
        dayTransitionContainer.SetActive(false);
        GameController.unPause();
        GameController.resetDay();
        isTransitioning = false;
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
    }
 }
