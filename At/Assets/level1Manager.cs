using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1Manager : MonoBehaviour
{
    float timer;
    public GameObject hero;
    public GameObject butonluHero;

    void Start()
    {
        hero.SetActive(false);
        butonluHero.SetActive(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 2f)
        {
            hero.SetActive(true);
            butonluHero.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
