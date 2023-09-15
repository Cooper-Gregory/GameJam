using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupThing : MonoBehaviour
{
    public bool isCollectableToInv;
    public bool isCarryable;
    public bool isRunOverPickUp;

    private GameObject player;

    [Header("Events")]
    public GameEvent onThingAcquired;

    // NOTE - You MUST have an event assigned here if you want to delete up the object, even if you don't need one, because the code will exit on a null event.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }

    public void CollectionEvent()
    {
        if (onThingAcquired != null)
        {
            onThingAcquired.Raise(this, null);
        }

    }
}
