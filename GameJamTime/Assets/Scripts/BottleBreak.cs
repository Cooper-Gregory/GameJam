using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BottleBreak : MonoBehaviour
{
    public AudioSource source;
    GameObject audioManager;

    public GameObject thisObject;
    public Vector3 sourceCoords;

    private void Start()
    {
        audioManager = GameObject.Find("SFX");
        source = audioManager.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        source.Play();
        this.gameObject.SetActive(false);

    }

    public void BossToSound()
    {
        sourceCoords = thisObject.transform.position;
    }

}
