using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    private float timeRemaining;
    private float totalTime;

    private float pauseBlinkLength = 1f;
    private float timeRemainingBlink;
    private bool isContainerActive = true;
    public List<Image> imagesToBlink = new List<Image>();

    public float startingHour = 6f;
    public float endingHour = 15f;
    public float tenMinsLenInSecs = 10f;

    public List<Sprite> numbers = new List<Sprite>();
    public List<Sprite> amPmLetters = new List<Sprite>();
    public List<Image> places = new List<Image>();

    private bool isPaused = false;
    private bool isDayOver = false;

    private int day = 0;

    public gameController GameController;

    void Start()
    {
        timeRemaining = (endingHour - startingHour) * 5 * tenMinsLenInSecs;
        totalTime = timeRemaining;

        timeRemainingBlink = pauseBlinkLength;
    }

    void Update()
    {
        if (isPaused == false) incrementTimer();
        else blinkAction();

        if (isDayOver == true) blinkAction();
    }

    public void resetDay()
    {
        timeRemaining = totalTime;
        isDayOver = false;
        day++;
        GameController.resetCustomerCount();
    }

    public bool getIsDayOver()
    {
        return isDayOver;
    }

    public void pause()
    {
        isPaused = true;
    }

    public void unPause()
    {
        isPaused = false;
        setTimerActive(true);
    }

    private void blinkAction()
    {
        if (timeRemainingBlink > 0)
        {
            timeRemainingBlink -= Time.deltaTime;
        }
        else
        {
            toggleTimerContainer();
            timeRemainingBlink = pauseBlinkLength;
        }
    }

    private void toggleTimerContainer()
    {
        if(isContainerActive == true)
        {
            setTimerActive(false);
        }
        else
        {
            setTimerActive(true);
        }
    }

    private void setTimerActive(bool isActive)
    {
        if(isActive == false)
        {
            foreach (Image imageToBlink in imagesToBlink)
            {
                var tempColor = imageToBlink.color;
                tempColor.a = 0.8f;
                imageToBlink.color = tempColor;
            }
        }
        else
        {
            foreach (Image imageToBlink in imagesToBlink)
            {
                var tempColor = imageToBlink.color;
                tempColor.a = 1f;
                imageToBlink.color = tempColor;
            }
        }
   
        isContainerActive = isActive;
    }

    private void incrementTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float[] time = computeTime();
            //Debug.Log(time[0] + ":" + time[1] + 0);
            displayTime(time);
        }
        else
        {
            isDayOver = true;
        }
    }

    private void displayTime(float[] time)
    {
        Image hoursPlaceTens = places[0];
        Image hoursPlaceOnes = places[1];
        int currentHour = (int) time[0];
        if(currentHour < 10)
        {
            hoursPlaceTens.sprite = numbers[0];
            hoursPlaceOnes.sprite = numbers[currentHour];
        }
        else
        {
            hoursPlaceTens.sprite = numbers[1];
            int currentHourOnes = currentHour - 10;
            hoursPlaceOnes.sprite = numbers[currentHourOnes];
        }

        Image minutesPlace = places[2];
        int currentMinutes = (int)time[1];
        minutesPlace.sprite = numbers[currentMinutes];

        Image amPmPlace = places[3];
        amPmPlace.sprite = amPmLetters[(int) time[2]]; 
    }

    private float[] computeTime()
    {
        //find out how much of the day has gone by
        float timePassed = totalTime - timeRemaining;

        //calculate hours and minutes
        float totalTenMinutes = timePassed / tenMinsLenInSecs;
        float hours = (float)Math.Floor(totalTenMinutes / 5f);
        float minutes = (float)Math.Round(totalTenMinutes - (hours * 5f));
        float actualHours = hours + startingHour;

        //am = 0, pm = 1
        float finalHours = 0f;
        float amPm = 0f;
        if (actualHours <= 12f)
        {
            finalHours = actualHours;
        }
        else
        {
            finalHours = actualHours - 12f;
            amPm = 1f;
        }

        float[] finalTime = {finalHours, minutes, amPm};
        return finalTime;
    }

    public int getDay()
    {
        return day;
    }
}
