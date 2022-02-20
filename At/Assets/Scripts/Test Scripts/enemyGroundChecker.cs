using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGroundChecker : MonoBehaviour
{
    public bool stop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        stop = true;
    }
}
