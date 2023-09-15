using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleBreak : MonoBehaviour
{
    public AudioSource source;
    GameObject audioManager;
    private void Start()
    {
        audioManager = GameObject.Find("SFX");
        source = audioManager.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        source.Play();
        this.gameObject.SetActive(false);
        Debug.Log("Stuff!");

    }
}
