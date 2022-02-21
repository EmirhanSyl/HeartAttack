using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool paused;
    public GameObject pauseScreen;

    private AudioSource _audioSource;
    private AudioClip _clicked;

    // Start is called before the first frame update
    void Start()
    {
       // _audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();

        }
        
        //if(Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
       // {
           // _audioSource.PlayOneShot(_clicked);
        //}
    }

    public void NextLevelGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

}
