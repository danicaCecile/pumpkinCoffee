using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngredientIndicator : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public GameObject textBoxObject;
    private gameController gameController;
    public string text;

    public void Start(){
        gameController = GameObject.Find("GameController").GetComponent<gameController>();
    }
    public void OnMouseOver(){
        if(gameController.isPaused == true) return;
        if(gameController.isLabelsOn == false) return;
        textBoxObject.SetActive(true);
        textBox.text = text;
        
    }

    public void OnMouseExit(){
        textBox.text = "";
        textBoxObject.SetActive(false);
    }
}
