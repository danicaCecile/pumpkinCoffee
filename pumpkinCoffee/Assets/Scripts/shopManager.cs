using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public GameObject shop;
    public GameObject shopHome;
    public GameObject buntingShop;
    public GameObject wallArtShop;
    public GameObject shelfShop;
    public GameObject wallColorShop;

    public GameObject backButton;

    private GameObject currentShopType;

    private bool isShopOpen = false;

    public GameObject wallColorObject0;
    public GameObject wallColorObject1;
    public GameObject wallColorObject2;
    private GameObject currentWallColor;

    public GameObject shelfObject0;
    public GameObject shelfObject1;
    public GameObject shelfObject2;
    private GameObject currentShelfObject;

    public GameObject buntingObject0;
    public GameObject buntingObject1;
    public GameObject buntingObject2;
    private GameObject currentBunting;

    public GameObject wallArtObject0;
    public GameObject wallArtObject1;
    public GameObject wallArtObject2;
    private GameObject currentWallArt;

    public bank Bank;
    public gameController GameController;

    void Start()
    {
        currentWallColor = wallColorObject2;
    }

    public void toggleShop()
    {

        if (isShopOpen == false)
        {
            shop.SetActive(true);
            isShopOpen = true;
            GameController.pause();
        }
        else
        {
            goBack();
            shop.SetActive(false);
            isShopOpen = false;
            GameController.unPause();
        }

        currentShopType = shopHome;
    }

    public void closeShop()
    {
        if(isShopOpen == true)
        {
            goBack();
            shop.SetActive(false);
            isShopOpen = false;
        }
    }

    public void goBack()
    {
        currentShopType.SetActive(false);
        shopHome.SetActive(true);
        backButton.SetActive(false);
    }

    private void navigateToShop(GameObject shopCategory)
    {
        shopCategory.SetActive(true);
        currentShopType = shopCategory;
        backButton.SetActive(true);

        shopHome.SetActive(false);
    }

    private void showBunting(GameObject option, float price)
    {
        if (Bank.canAfford(price))
        {
            if (currentBunting != null) currentBunting.SetActive(false);
            currentBunting = option;
            option.SetActive(true);
            Bank.subBal(price);
        }
    }

    private void showWallArt(GameObject option, float price)
    {
        if (Bank.canAfford(price))
        {
            if (currentWallArt != null) currentWallArt.SetActive(false);
            currentWallArt = option;
            option.SetActive(true);
            Bank.subBal(price);
        }
    }

    private void showShelfObject(GameObject option, float price)
    {
        if (Bank.canAfford(price))
        {
            if (currentShelfObject != null) currentShelfObject.SetActive(false);
            currentShelfObject = option;
            option.SetActive(true);
            Bank.subBal(price);
        }
    }

    private void showWallColor(GameObject option, float price)
    {
        if (Bank.canAfford(price)) {
            currentWallColor.SetActive(false);
            currentWallColor = option;
            option.SetActive(true);
            Bank.subBal(price);
        }
    }

    //order = bunting, shelf object, wall art
    public bool[] getChecklistItems()
    {
        bool[] checklistItems = { false, false, false };

        if (currentBunting != null) checklistItems[0] = true;
        if (currentShelfObject != null) checklistItems[1] = true;
        if (currentWallArt != null) checklistItems[2] = true;

        return checklistItems;
    }

    //functions for changing shop type for buttons
    public void buntingShopNav()
    {
        navigateToShop(buntingShop);
    }

    public void wallArtShopNav()
    {
        navigateToShop(wallArtShop);
    }

    public void wallColorShopNav()
    {
        navigateToShop(wallColorShop);
    }

    public void shelfShopNav()
    {
        navigateToShop(shelfShop);
    }

    //for shop buttons to buy decorations
    //bunting
    public void buyOrangePurpleBunting()
    {
        showBunting(buntingObject0, 70f);
    }

    public void buyGreenYellowBunting()
    {
        showBunting(buntingObject1, 50f);
    }

    public void buyYellowBrownBunting()
    {
        showBunting(buntingObject2, 60f);
    }

    //art
    public void buySpookyArt()
    {
        showWallArt(wallArtObject0, 70f);
    }

    public void buyModernArt()
    {
        showWallArt(wallArtObject1, 60f);
    }

    public void buyNatureArt()
    {
        showWallArt(wallArtObject2, 50f);
    }

    //shelf decor
    public void buyPumpkin()
    {
        showShelfObject(shelfObject0, 70f);
    }

    public void buyPottedPlant()
    {
        showShelfObject(shelfObject1, 60f);
    }

    public void buySpiderWeb()
    {
        showShelfObject(shelfObject2, 50f);
    }

    //wall colors
    public void buyYellow()
    {
        showWallColor(wallColorObject0, 20f);
    }

    public void buyPurple()
    {
        showWallColor(wallColorObject1, 20f);
    }

    public void buyGreen()
    {
        showWallColor(wallColorObject2, 0f);
    }
}
