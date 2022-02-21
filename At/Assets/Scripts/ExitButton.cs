using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    

    StartCoroutine(wait());

    IEnumerator wait()
    {
        yield return new WaitForSeconds(8f);
        //Application.Quit();
        //Debug.Log("Yess");
    }

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Yess");

    }
    

}
