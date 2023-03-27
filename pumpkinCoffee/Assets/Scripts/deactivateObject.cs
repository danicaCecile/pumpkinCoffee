using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateObject : MonoBehaviour
{
    public GameObject obj;

    public void deactivateGameObject()
    {
        obj.SetActive(false);
    }
}
