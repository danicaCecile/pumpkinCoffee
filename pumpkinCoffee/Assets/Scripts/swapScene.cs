using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class swapScene : MonoBehaviour
{
    public string sceneName;
    public bool withPause = false;

    public void sceneSwap()
    {
        if(withPause == false) SceneManager.LoadScene(sceneName);
        else StartCoroutine(swapWithPause());
    }

    private IEnumerator swapWithPause()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(sceneName);
    }
}
