using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutScene : MonoBehaviour
{
    public GameObject flyer;
    public GameObject text1;
    public GameObject text2;
    public GameObject checklist;

    public float pause = 5f;

    void Start()
    {
        StartCoroutine(startCutscene());
    }

    private IEnumerator startCutscene()
    {
        text1.SetActive(true);

        yield return new WaitForSeconds(pause-2);

        text1.SetActive(false);
        flyer.SetActive(true);

        yield return new WaitForSeconds(pause);

        flyer.SetActive(false);
        text2.SetActive(true);

        yield return new WaitForSeconds(pause);

        text2.SetActive(false);
        checklist.SetActive(true);
    }
}
