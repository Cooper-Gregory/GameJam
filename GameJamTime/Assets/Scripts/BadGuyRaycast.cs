using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuyRaycast : MonoBehaviour
{
    public GameObject playerToLookFor;
    private Vector3 collision = Vector3.zero;
    public Vector3 playerPosition;

    [Header("Raycast Info")]
    public LayerMask playerHit;
    //public LayerMask wallHit;
    public float raycastRange = 100;
    public bool isChasing = false;


    public NavMeshAgent agent;

    void Update()
    {
        BadGuyRay();
        PlayerToFind();
    }

    public void BadGuyRay()
    {
        Ray ray = new Ray(this.transform.position, playerPosition);//The ray being cast to the player's current position
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastRange, playerHit))//If the ray is hitting the player layer within the set range
        {
            agent.SetDestination(hit.point);
            collision = hit.point; // sets v3 position to the hitpoint
            Debug.Log("I have hit something");
        }
    }

    public void PlayerToFind()
    {
        if (isChasing)
        {
            playerPosition = playerToLookFor.transform.position;   
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collision, radius: 0.2f);
    }
}
