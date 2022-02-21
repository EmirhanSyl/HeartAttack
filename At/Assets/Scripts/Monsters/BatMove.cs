using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    GameObject hero;
    public float speed;
    public float health = 100;
    float lastHealth;
    Animator _anim;
    bool dead;
    float timer;
    Rigidbody2D rigi;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        _anim = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        lastHealth = health;
    }

    
    void Update()
    {
        if(Vector2.Distance(hero.transform.position, gameObject.transform.position) < 15f && !dead)
        {
            Vector3 distace = gameObject.transform.position - hero.transform.position;

             transform.Translate(-distace.normalized * Time.deltaTime * speed);
        }

        if(lastHealth != health)
        {
            _anim.SetTrigger("Hitted");
            lastHealth = health;
        }
        
        if(health <= 0)
        {
            _anim.SetTrigger("Dead");
            dead = true;
            Destroy(gameObject, 2f);
            rigi.constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !dead)
        {
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                if(gameObject.CompareTag("Ghost"))
                {
                    _anim.SetTrigger("Attack");
                }
                collision.gameObject.GetComponent<HeroMove>().health -= 1;
                timer = 0;
            }            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //timer = 0;
    }
}
