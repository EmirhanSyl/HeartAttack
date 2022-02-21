using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public GameObject hero;
    public float time = 0;

    private void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        time += Time.deltaTime;

        if(collision.CompareTag("Player") && time > 0.8f)
        {
            hero.GetComponent<HeroMove>().health -= 1;
            time = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        time = 0;
    }
}
