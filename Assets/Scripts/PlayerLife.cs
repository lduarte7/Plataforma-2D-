using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb;

    [SerializeField] private AudioSource Death;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Death.Play();
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; 
         //para não conseguir movimentar o personagem depois de morrer
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
