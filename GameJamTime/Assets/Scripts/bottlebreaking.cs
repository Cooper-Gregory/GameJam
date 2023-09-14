using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottlebreaking : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        DestroyObject(gameObject);
    }
}