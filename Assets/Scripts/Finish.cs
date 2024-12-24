using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishAudioEffect;
    [SerializeField] private GameObject collectItems;
    private Animator setFlag;
    private bool levelCompleted = false;
    private bool isSetFlag = false;
    void Start()
    {
        finishAudioEffect = GetComponent<AudioSource>();
        setFlag = GetComponent<Animator>();

    }

    void Update()
    {   
        //check if all apple is collected
        if (collectItems.transform.childCount == 0)
        {
            setFlag.SetTrigger("setFlag");
            isSetFlag = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player" && !levelCompleted && isSetFlag)
        {
            finishAudioEffect.Play();
            levelCompleted = true;
            Invoke("CompletedLevel", 1.5f);
        }

    }

    private void CompletedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
