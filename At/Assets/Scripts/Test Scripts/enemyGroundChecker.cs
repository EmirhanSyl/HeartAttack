using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGroundChecker : MonoBehaviour
{
    public bool stop;
    private void OnTriggerExit2D(Collider2D collision)
    {
        stop = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        stop = false;
    }
}
