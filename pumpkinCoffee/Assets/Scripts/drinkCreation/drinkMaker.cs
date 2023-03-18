using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkMaker : MonoBehaviour
{
    public GameObject mugObject;
    public GameObject drinkObject;
    public GameObject creamObject;
    public GameObject sprinklesObject;

    public AudioSource drinkClink;
    public AudioSource drinkMix;
    public AudioSource whippedCream;
    public AudioSource sprinkles;

    private SpriteRenderer mug;
    private SpriteRenderer drink;
    private SpriteRenderer cream;
    private SpriteRenderer sprinkles;

    private bool mugAdded;
    private bool drinkAdded;
    private bool creamAdded;
    private bool sprinklesAdded;
    private int drinkStage = 0;

    private bool isPaused = false;

    private List<Sprite> drinkConfig = new List<Sprite>();

    void Start()
    {
        mug = mugObject.GetComponent<SpriteRenderer>();
        drink = drinkObject.GetComponent<SpriteRenderer>();
        cream = creamObject.GetComponent<SpriteRenderer>();
        sprinkles = sprinklesObject.GetComponent<SpriteRenderer>();
    }

    public void activateMug(Sprite ingredient)
    {
        if (isPaused == false)
        {
            mugObject.SetActive(true);
            mug.sprite = ingredient;

            if (drinkStage == 0) drinkStage = 1;

            if (mugAdded == false)
            {
                mugAdded = true;
                drinkConfig.Add(ingredient);
            }
            else drinkConfig[0] = ingredient;

            drinkClink.Play();
        }
    }

    public void activateDrink(Sprite ingredient)
    {
        if (isPaused == false)
        {
            if (drinkStage >= 1)
            {
                drinkObject.SetActive(true);

                drink.sprite = ingredient;

                if (drinkStage == 1) drinkStage = 2;

                if (drinkAdded == false)
                {
                    drinkAdded = true;
                    drinkConfig.Add(ingredient);
                }
                else drinkConfig[1] = ingredient;

                drinkMix.Play();
            }
        }
    }

    public void activateCream(Sprite ingredient)
    {
        if (isPaused == false)
        {
            if (drinkStage >= 2)
            {
                creamObject.SetActive(true);

                cream.sprite = ingredient;

                if (drinkStage == 2) drinkStage = 3;

                if (creamAdded == false)
                {
                    creamAdded = true;
                    drinkConfig.Add(ingredient);
                }
                else drinkConfig[2] = ingredient;

                whippedCream.Play();
            }
        }
    }

    public void activateSprinkles(Sprite ingredient)
    {
        if(isPaused == false)
        {
            if (drinkStage == 3)
            {
                sprinklesObject.SetActive(true);

                sprinkles.sprite = ingredient;

                if (sprinklesAdded == false)
                {
                    sprinklesAdded = true;
                    drinkConfig.Add(ingredient);
                }
                else drinkConfig[3] = ingredient;

                sprinkles.Play();
            }
        }
    }

    public void clearDrink()
    {
        mugAdded = false;
        drinkAdded = false;
        creamAdded = false;
        sprinklesAdded = false;

        drinkStage = 0;

        mugObject.SetActive(false);
        drinkObject.SetActive(false);
        creamObject.SetActive(false);
        sprinklesObject.SetActive(false);

        drinkConfig.Clear();
    }

    public List<Sprite> getConfig()
    {
        return drinkConfig;
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
