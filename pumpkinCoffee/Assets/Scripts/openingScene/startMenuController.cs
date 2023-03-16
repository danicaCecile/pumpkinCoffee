using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenuController : MonoBehaviour
{
    public GameObject credits;
    public GameObject startMenu;
    public GameObject howTo;
    public GameObject characters;
    private GameObject currentScene;

    void Start()
    {
        currentScene = startMenu;
    }

    public void showCredits()
    {
        currentScene.SetActive(false);
        characters.SetActive(false);
        credits.SetActive(true);
        currentScene = credits;
    }

    public void showStartMenu()
    {
        currentScene.SetActive(false);
        startMenu.SetActive(true);
        characters.SetActive(true);
        currentScene = startMenu;
    }

    public void showHowTo()
    {
        currentScene.SetActive(false);
        howTo.SetActive(true);
        characters.SetActive(false);
        currentScene = howTo;
    }
}
