using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{   
    private Rigidbody2D rigid;
    private Animator anim;
    [SerializeField] private AudioSource deadSoundEffect;
    [SerializeField] private bool wannaDie = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Trap") && wannaDie)
        {
            Die();
        }
    }

    private void Die() {
        anim.SetTrigger("death");
        deadSoundEffect.Play();
        //stop character from moving after death
        rigid.bodyType = RigidbodyType2D.Static;

        Invoke("ReloadLevel", 2f);
    }

    private void ReloadLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
