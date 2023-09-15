using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
 
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Cooper");
        }
    }
}
