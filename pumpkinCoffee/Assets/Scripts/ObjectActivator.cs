using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public List<GameObject> objectsToDeactivate = new List<GameObject>();
    public List<GameObject> objectsToActivate = new List<GameObject>();

    public void ActivateObjects()
    {
        foreach(GameObject gameobject in objectsToActivate) gameobject.SetActive(true);
    }

    public void DeactivateObjects()
    {
        foreach(GameObject gameobject in objectsToDeactivate) gameobject.SetActive(false);
    }
}
