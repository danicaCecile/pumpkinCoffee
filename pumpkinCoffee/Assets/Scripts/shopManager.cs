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


    public GameObject trixieCraftShelfLock;
    public GameObject trixieCraftShelfLabel;
    public GameObject trixieCraftArtLock;
    public GameObject trixieCraftArtLabel;
    public GameObject trixieCraftBuntingLock;
    public GameObject trixieCraftBuntingLabel;

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

    public void unlockBunting(){
        trixieCraftBuntingLock.SetActive(false);
        trixieCraftBuntingLabel.SetActive(true);
    }

    public void unlockShelf(){
        trixieCraftShelfLock.SetActive(false);
        trixieCraftShelfLabel.SetActive(true);
    }

    public void unlockArt(){
        trixieCraftArtLock.SetActive(false);
        trixieCraftArtLabel.SetActive(true);
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

    public void showBunting(GameObject option, float price, GameObject priceLabel)
    {
        if (Bank.canAfford(price))
        {
            if (currentBunting != null) currentBunting.SetActive(false);
            currentBunting = option;
            option.SetActive(true);
            Bank.subBal(price);
            if(priceLabel != null)priceLabel.SetActive(false);
        }
    }

    public void showWallArt(GameObject option, float price, GameObject priceLabel)
    {
        if (Bank.canAfford(price))
        {
            if (currentWallArt != null) currentWallArt.SetActive(false);
            currentWallArt = option;
            option.SetActive(true);
            Bank.subBal(price);
            if(priceLabel != null)priceLabel.SetActive(false);
        }
    }

    public void showShelfObject(GameObject option, float price, GameObject priceLabel)
    {
        if (Bank.canAfford(price))
        {
            if (currentShelfObject != null) currentShelfObject.SetActive(false);
            currentShelfObject = option;
            option.SetActive(true);
            Bank.subBal(price);
            if(priceLabel != null)priceLabel.SetActive(false);
        }
    }

    public void showWallColor(GameObject option, float price, GameObject priceLabel)
    {
        if (Bank.canAfford(price)) {
            currentWallColor.SetActive(false);
            currentWallColor = option;
            option.SetActive(true);
            Bank.subBal(price);
            if(priceLabel != null) priceLabel.SetActive(false);
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
    private float orangePurpleBuntingPrice = 70f;
    public GameObject orangePurpleBuntingPriceUI;
    public void buyOrangePurpleBunting()
    {
        showBunting(buntingObject0, orangePurpleBuntingPrice, orangePurpleBuntingPriceUI);
        orangePurpleBuntingPrice = 0f;
    }

    private float greenYellowBuntingPrice = 50f;
    public GameObject greenYellowBuntingPriceUI;
    public void buyGreenYellowBunting()
    {
        showBunting(buntingObject1, greenYellowBuntingPrice, greenYellowBuntingPriceUI);
        greenYellowBuntingPrice = 0f;
    }

    private float yellowBrownBuntingPrice = 60f;
    public GameObject yellowBrownBuntingPriceUI;
    public void buyYellowBrownBunting()
    {
        showBunting(buntingObject2, yellowBrownBuntingPrice, yellowBrownBuntingPriceUI);
        yellowBrownBuntingPrice = 0f;
    }

    //art
    private float spookyArtPrice = 70f;
    public GameObject spookyArtPriceUI;
    public void buySpookyArt()
    {
        showWallArt(wallArtObject0, spookyArtPrice, spookyArtPriceUI);
        spookyArtPrice = 0f;
    }

    private float modernArtPrice = 60f;
    public GameObject modernArtPriceUI;
    public void buyModernArt()
    {
        showWallArt(wallArtObject1, modernArtPrice, modernArtPriceUI);
        modernArtPrice = 0f;
    }

    private float natureArtPrice = 50f;
    public GameObject natureArtPriceUI;
    public void buyNatureArt()
    {
        showWallArt(wallArtObject2, natureArtPrice, natureArtPriceUI);
        natureArtPrice = 0f;
    }

    //shelf decor
    private float pumpkinShelfPrice = 70f;
    public GameObject pumpkinShelfPriceUI;
    public void buyPumpkin()
    {
        showShelfObject(shelfObject0, pumpkinShelfPrice, pumpkinShelfPriceUI);
        pumpkinShelfPrice = 0f;
    }

    private float plantShelfPrice = 60f;
    public GameObject plantShelfPriceUI;
    public void buyPottedPlant()
    {
        showShelfObject(shelfObject1, plantShelfPrice, plantShelfPriceUI);
        plantShelfPrice = 0f;
    }

    private float webShelfPrice = 50f;
    public GameObject webShelfPriceUI;
    public void buySpiderWeb()
    {
        showShelfObject(shelfObject2, webShelfPrice, webShelfPriceUI);
        webShelfPrice = 0f;
    }

    //wall colors
    private float yellowPrice = 20f;
    public GameObject yellowPriceUI;
    public void buyYellow()
    {
        showWallColor(wallColorObject0, yellowPrice, yellowPriceUI);
        yellowPrice = 0f;
    }

    private float purplePrice = 20f;
    public GameObject purplePriceUI;
    public void buyPurple()
    {
        showWallColor(wallColorObject1, purplePrice, purplePriceUI);
        purplePrice = 0f;
    }

    public void buyGreen()
    {
        showWallColor(wallColorObject2, 0f, null);
    }
}
