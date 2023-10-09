using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameManager : MonoBehaviour
{
    public gameController GameController;
    public List<GameObject> itemsToDeactivate = new List<GameObject>();
    public List<GameObject> itemsToActivate = new List<GameObject>();
    public List<GameObject> characters = new List<GameObject>();
    public GameObject trixie;
    public GameObject crown;
    public GameObject laceHat;
    public GameObject pumpkin;

    public void end()
    {
        GameController.pause();
        foreach(GameObject item in itemsToDeactivate)
        {
            item.SetActive(false);
        }

        foreach(GameObject item in itemsToActivate)
        {
            item.SetActive(true);
        }

        GameObject trixieHat;
        if(GameController.getChosenMug() == "heart") trixieHat = crown;
        else if(GameController.getChosenMug() == "pumpkin") trixieHat = pumpkin;
        else if(GameController.getChosenMug() == "lace") trixieHat = laceHat;
        else trixieHat = getRandomHat();

        if(didWin() == true)
        {
            foreach(GameObject character in characters)
            {
                character.SetActive(true);
            }
            trixieHat.SetActive(true);
            trixie.SetActive(true);
        }
        else
        {
            getRandomCharacter().SetActive(true);
            if(GameController.getTrixieInteractions() >= 1){
                trixieHat.SetActive(true);
                trixie.SetActive(true);
            }
        }
    }

    public GameObject getRandomHat(){
        List<GameObject> hats = new List<GameObject>();
        hats.Add(crown);
        hats.Add(laceHat);
        hats.Add(pumpkin);
        int rand = Random.Range(0, 3);
        return hats[rand];
    }
    public GameObject getRandomCharacter()
    {
        int rand = Random.Range(0, 4);
        return characters[rand];
    }

    public bool didWin()
    {
        bool[] checklistItems = GameController.getChecklistItems();
        int numOfItems = 0;

        if (checklistItems[0] == true) numOfItems++;
        if (checklistItems[2] == true) numOfItems++;
        if (checklistItems[1] == true) numOfItems++;

        if (numOfItems == 3) return true;
        else return false;
    }
}
