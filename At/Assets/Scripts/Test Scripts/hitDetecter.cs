using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetecter : MonoBehaviour
{
    //public Animator HeroAnim;
    public bool hitted;
    [SerializeField] float minDamage = 5f;
    [SerializeField] float maxDamage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) // && HeroAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack")
        {
            hitted = true;
            float damage = Random.Range(minDamage, maxDamage);
            collision.GetComponent<Movement>().health -= damage; 
        }
        else
        {
            hitted = false;
        }
    }

}
