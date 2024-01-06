using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPairPress : MonoBehaviour
{
    public Image button0;
    public Image button1;

    public Sprite pressedButton;
    public Sprite unpressedButton;

    public void pressButton0(){
        button0.sprite = pressedButton;
        button1.sprite = unpressedButton;
    }

    public void pressButton1(){
        button0.sprite = unpressedButton;
        button1.sprite = pressedButton;
    }
}
