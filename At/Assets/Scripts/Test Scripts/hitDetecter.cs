using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetecter : MonoBehaviour
{
    public Animator HeroAnim;
    public bool hitted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && HeroAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            hitted = true;
            float damage = Random.Range(5f, 20f);
            collision.GetComponent<Movement>().health -= damage; 
        }
        else
        {
            hitted = false;
        }
    }

}
