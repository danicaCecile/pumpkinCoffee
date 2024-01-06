using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject primaryButtons;
    public GameObject settingsMenu;
    public gameController gameController;
    private bool isPauseMenuOpen = false;
    public shopManager shopManager;
    public GameObject soundEffects;
    public AudioSource backgroundAudioSource;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && isPauseMenuOpen == false) pause();
        else if(Input.GetKeyDown(KeyCode.Escape) && isPauseMenuOpen == true) unPause();
    }
    public void pause(){
        pauseMenu.SetActive(true);
        gameController.pause();
        isPauseMenuOpen = true;
        shopManager.closeShop();
    }

    public void unPause(){
        settingsMenu.SetActive(false);
        primaryButtons.SetActive(true);
        pauseMenu.SetActive(false);
        gameController.unPause();
        isPauseMenuOpen = false;
    }

    public void openSettings(){
        primaryButtons.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void closeSettings(){
        primaryButtons.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void setLabels(bool isLabelsOn){
        gameController.isLabelsOn = isLabelsOn;
    }

    public void setPicPrompts(bool isPicPrompt){
        gameController.isPicPrompt = isPicPrompt;
    }

    public void setSoundEffects(bool isSoundEffectsOn){
        soundEffects.SetActive(isSoundEffectsOn);
    }

    public void setMusic(bool isMusicOn){
        backgroundAudioSource.mute = isMusicOn;
    }
}
