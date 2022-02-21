using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Button _button;

    public void Start()
    {
        _button = GetComponent<Button>();
        Invoke("interact", 7.0f);
    }

    public void interact()
    {
        _button.GetComponent<Button>().inter
    }

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Yess");

    }
    

}
