using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleShatter : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        DestroyObject(gameObject);
    }
}