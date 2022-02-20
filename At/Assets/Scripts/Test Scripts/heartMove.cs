using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartMove : MonoBehaviour
{
    Rigidbody2D rigKalp;
    Collider2D coll;
    Animator animKalp;
    
    GameObject hero;

    bool crash;
    float time;
    float lastSpeed;
    int multiply = 0;

    public float xForce = 20;
    public float yForce = 200;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        rigKalp = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        animKalp = GetComponent<Animator>();
    }

   
    void Update()
    {
        if(gameObject.GetComponent<dragger>().kalpFree)
        {
            time += Time.deltaTime;
            if(time > 2f)
            {
                animKalp.SetTrigger("Jump");
                StartCoroutine(jump());
                time = 0f;
            }
        }

        if(!crash)
        {
            lastSpeed = rigKalp.velocity.magnitude;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            int damage = 0;
            crash = true;
            if(lastSpeed < 4f)
            {
                damage = Random.Range(2, 5);
                collision.gameObject.GetComponent<Movement>().health -= damage;

                //Instantiate(HalfKalp, startPos.position, startPos.rotation);
                hero.GetComponent<HeroMove>().health -= 1;
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
            else if(lastSpeed > 4f && lastSpeed < 15f)
            {
                damage = Random.Range(4, 15);
                collision.gameObject.GetComponent<Movement>().health -= damage;

                //Instantiate(HalfKalp, startPos.position, startPos.rotation);
                hero.GetComponent<HeroMove>().health -= 1;
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }
            else if(lastSpeed > 15f)
            {
                damage = Random.Range(12, 20);
                collision.gameObject.GetComponent<Movement>().health -= damage;

                //Instantiate(HalfKalp, startPos.position, startPos.rotation);
                hero.GetComponent<HeroMove>().health -= 1;
                gameObject.SetActive(false);
                //Destroy(gameObject);
            }

        }
    }

    IEnumerator jump()
    {        
        if(multiply == 0 || multiply == 2)
        {
            multiply = Random.Range(-1, 2);
        }
        yield return new WaitForSeconds(0.3f);
        rigKalp.AddForce(new Vector2(xForce * multiply, yForce));
    }
}
