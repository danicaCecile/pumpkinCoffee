using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    private float timeRemaining;
    private float totalTime;

    public float startingHour = 6f;
    public float endingHour = 15f;
    public float tenMinsLenInSecs = 10f;

    public List<Sprite> numbers = new List<Sprite>();
    public List<Sprite> amPmLetters = new List<Sprite>();
    public List<Image> places = new List<Image>();

    void Start()
    {
        timeRemaining = (endingHour - startingHour) * 5 * tenMinsLenInSecs;
        totalTime = timeRemaining;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float[] time = computeTime();
            //Debug.Log(time[0] + ":" + time[1] + 0);
            displayTime(time);
        }
    }

    public void resetDay()
    {
        timeRemaining = totalTime;
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
}
