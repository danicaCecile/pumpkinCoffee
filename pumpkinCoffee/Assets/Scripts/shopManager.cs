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

    public void toggleShop()
    {
        if (isShopOpen == false)
        {
            shop.SetActive(true);
            isShopOpen = true;
        }
        else
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

        currentShopType = shopHome;
    }

    private void navigateToShop(GameObject shopCategory)
    {
        shopCategory.SetActive(true);
        currentShopType = shopCategory;
        backButton.SetActive(true);

        shopHome.SetActive(false);
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
}
