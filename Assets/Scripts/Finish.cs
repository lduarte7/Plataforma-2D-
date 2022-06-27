using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSound.Play();
            CompleteLevel();
            End();
        }
    }
    private void CompleteLevel()
    {
        StartCoroutine(waiting());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(3);
    }

    private void End()
    {
        anim.SetTrigger("end");
    }
}
