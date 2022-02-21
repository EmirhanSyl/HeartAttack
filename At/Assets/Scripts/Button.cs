using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(duldul());
        }
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger("Click");
        StartCoroutine(duldul());
    }

    IEnumerator duldul()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
