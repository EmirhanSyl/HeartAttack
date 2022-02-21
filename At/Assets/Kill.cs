using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public GameObject hero;
    public Transform startPos;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Respawn());
            hero.GetComponent<HeroMove>().dead = true;
        }
    }

    IEnumerator Respawn()
    {
        hero.GetComponent<Animator>().SetTrigger("Fall");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

}
