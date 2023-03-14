using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameManager : MonoBehaviour
{
    public gameController GameController;
    public List<GameObject> itemsToDeactivate = new List<GameObject>();
    public List<GameObject> itemsToActivate = new List<GameObject>();
    public List<GameObject> characters = new List<GameObject>();

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

        if(didWin() == true)
        {
            foreach(GameObject character in characters)
            {
                character.SetActive(true);
            }
        }
        else
        {
            getRandomCharacter().SetActive(true);
        }
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
