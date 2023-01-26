using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer : MonoBehaviour
{
    public drinkSeller drinkOrder;

    public List<GameObject> customers = new List<GameObject>();
    private GameObject currentCustomer;
    private int customerIndex = 0;
    private Sprite originalFace;

    private bool customerEntering = false;
    private bool customerLeaving = false;

    public GameObject characterBubble;
    public GameObject emotionObject;
    public GameObject happyEmote;
    public GameObject sadEmote;

    public List<Sprite> happyFaces = new List<Sprite>();
    public List<Sprite> sadFaces = new List<Sprite>();

    public List<Animator> blinkAnimators = new List<Animator>();


    void Start()
    {
        getNewCustomer();
    }

    void Update()
    {
        if(customerEntering == true)
        {
            currentCustomer.transform.position += new Vector3(-0.004f, 0, 0);
            if (currentCustomer.transform.position.x <= 2.16f)
            {
                customerEntering = false;
                showBubble();
            }
        }

        if (customerLeaving == true)
        {
            currentCustomer.transform.position += new Vector3(0.004f, 0, 0);
            if (currentCustomer.transform.position.x >= 5.25f)
            {
                customerLeaving = false;
                getNewCustomer();
            }
        }
    }

    public void getNewCustomer()
    {
        int rand = Random.Range(0, 4);
        currentCustomer = customers[rand];
        customerIndex = rand;
        customerEntering = true;
    }

    public void customerLeave()
    {
        customerLeaving = true;
        currentCustomer.GetComponent<SpriteRenderer>().sprite = originalFace;
        characterBubble.SetActive(false);
    }

    public void emote(bool isHappy)
    {
        blinkAnimators[customerIndex].enabled = false;
        SpriteRenderer spriteRenderer = currentCustomer.GetComponent<SpriteRenderer>();
        originalFace = spriteRenderer.sprite;

        if (isHappy == true)
        {
            happyEmote.SetActive(true);
            spriteRenderer.sprite = happyFaces[customerIndex];
        }
        else
        {
            sadEmote.SetActive(true);
            spriteRenderer.sprite = sadFaces[customerIndex];
        }
    }

    public void hideBubble()
    {
        happyEmote.SetActive(false);
        sadEmote.SetActive(false);
        characterBubble.SetActive(false);
    }

    public void showBubble()
    {
        characterBubble.SetActive(true);
    }
}