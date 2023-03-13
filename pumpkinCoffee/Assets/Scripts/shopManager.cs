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

    //for game win conditions
    private bool hasBunting = false;
    private bool hasPictures = false;
    private bool hasShelfObject = false;

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

    private int buyDecoration(GameObject decoration, float price)
    {
        if (Bank.canAfford(price))
        {
            decoration.SetActive(true);
            Bank.subBal(price);
            return 0;
        }
        else return -1;
    }

    private void showBunting(GameObject option, float price)
    {
        if (currentBunting != null) currentBunting.SetActive(false);
        currentBunting = option;
        buyDecoration(option, price);
    }

    private void showWallArt(GameObject option, float price)
    {
        if (currentWallArt != null) currentWallArt.SetActive(false);
        currentWallArt = option;
        buyDecoration(option, price);
    }

    private void showShelfObject(GameObject option, float price)
    {
        if (currentShelfObject != null) currentShelfObject.SetActive(false);
        currentShelfObject = option;
        buyDecoration(option, price);
    }

    private void showWallColor(GameObject option, float price)
    {
        currentWallColor.SetActive(false);
        currentWallColor = option;
        buyDecoration(option, price);
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
