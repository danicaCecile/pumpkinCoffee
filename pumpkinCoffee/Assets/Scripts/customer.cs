using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer : MonoBehaviour
{
    public drinkSeller drinkOrder;

    public List<GameObject> customers = new List<GameObject>();
    private GameObject currentCustomer;

    private bool customerEntering = false;
    private bool customerLeaving = false;

    public GameObject characterBubble;

    void Start()
    {
        getNewCustomer();
    }

    void Update()
    {
        if(customerEntering == true)
        {
            currentCustomer.transform.position += new Vector3(-0.008f, 0, 0);
            if (currentCustomer.transform.position.x <= 2.16f)
            {
                customerEntering = false;
                characterBubble.SetActive(true);
            }
        }

        if (customerLeaving == true)
        {
            currentCustomer.transform.position += new Vector3(0.008f, 0, 0);
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
        customerEntering = true;
    }

    public void customerLeave()
    {
        customerLeaving = true;
        characterBubble.SetActive(false);
    }
}