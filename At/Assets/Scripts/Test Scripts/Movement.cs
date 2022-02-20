using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float health = 100f;
    public float lastHealth;
    public float speed = 5f;
    [SerializeField]float Distace;
    int direction;

    bool stopMovement;
    public GameObject hero;

    Rigidbody2D rigHero;
    Animator animHero;
    SpriteRenderer srHero;

    void Start()
    {
        rigHero = GetComponent<Rigidbody2D>();
        animHero = GetComponent<Animator>();
        srHero = GetComponent<SpriteRenderer>();
        hero = GameObject.FindGameObjectWithTag("Player");
        
        lastHealth = health;
    }

    void FixedUpdate()
    {
        if(!stopMovement)
        {
            rigHero.velocity = new Vector2(speed * direction, 0f);
        }
        Distace = gameObject.transform.position.x - hero.transform.position.x;

    }

    void Update()
    {
        
        if(lastHealth != health)
        {
            animHero.SetTrigger("Hit");
            lastHealth = health;

        }

        if (health <= 0)
        {
            animHero.SetTrigger("Dead");
            Destroy(gameObject, 2);
        }


        if(animHero.GetBool("ShieldUp"))
        {
            stopMovement = true;
        }
        else
        {
            stopMovement = false;
        }
        
        if(Distace > 3 && Distace < 10 )
        {
            srHero.flipX = true;
            direction = -1;
            animHero.SetBool("Attack", false);
        }        
        else if(Distace < -3 && Distace > -10)
        {
            srHero.flipX = false;
            direction = 1;
            animHero.SetBool("Attack", false);
        }
        else if(Distace > -3 && Distace < 3)
        {
            animHero.SetBool("Attack", true);
            direction = 0;            
        }
        else
        {
            animHero.SetBool("Attack", false);
        }

    }

    void ShieldUp()
    {

    }

    void Attack()
    {

    }

}
