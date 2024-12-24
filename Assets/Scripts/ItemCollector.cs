using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{   
    private int count = 0;
    [SerializeField] private Text fullChangeText;
    [SerializeField] private string contentText = "Apples";
    [SerializeField] private AudioSource collectItemSoundEffect;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Apple")) {
            Destroy(collider.gameObject);

            collectItemSoundEffect.Play();     

            count++;
            fullChangeText.text = contentText + ": " + count;
        }    
    }
}
