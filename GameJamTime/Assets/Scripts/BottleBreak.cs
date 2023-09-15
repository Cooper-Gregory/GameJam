using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BottleBreak : MonoBehaviour
{
    public BadGuyRaycast boss;


    public AudioSource source;
    GameObject audioManager;

    private GameObject thisObject;
    public Vector3 sourceCoords;


    private void Start()
    {
        thingsToStart();
    }

    private void OnCollisionEnter(Collision other)
    {
        source.Play();
        //StartCoroutine(waitingTime());
        this.gameObject.SetActive(false);

    }

    IEnumerator waitingTime()
    {
        yield return new WaitForSeconds(4);
    }

    public void BossToSound()
    {
        sourceCoords = thisObject.transform.position;
    }

    public void SoundWasHeard()
    {
        if (thisObject)
        {
            boss.agent.SetDestination(sourceCoords);
        }
    }

    private void thingsToStart()
    {
        thisObject = GetComponent<GameObject>();
        boss = GetComponent<BadGuyRaycast>();
        audioManager = GameObject.Find("SFX");
        source = audioManager.GetComponent<AudioSource>();
    }
}
