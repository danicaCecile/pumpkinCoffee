using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checklistManager : MonoBehaviour
{
    public gameController gameController;

    public Sprite check;
    public Image buntingBox;
    public Image wallArtBox;
    public Image shelfObjectBox;

    private bool didWin;

    public void checkItems()
    {
        bool[] checklistItems = gameController.getChecklistItems();

        if (checklistItems[0] == true) buntingBox.sprite = check;
        if (checklistItems[2] == true) shelfObjectBox.sprite = check;
        if (checklistItems[1] == true) wallArtBox.sprite = check;
    }
}
