using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuyRaycast : MonoBehaviour
{
    public GameObject playerToLookFor;
    public Vector3 playerPosition;
    public GameObject enemy;
    public Vector3 enemyPosition;

    public Vector3 direction;
    private RaycastHit hit;

    [Header("Raycast Info")]
    public LayerMask playerHit;
    //public LayerMask wallHit;
    public float sightRange;
    public float playerDistance;

    public bool isLooking = true;
    public bool isChasing = false;
    bool isActive = false;
    public Ray ray = new Ray();
    public Vector3 offset;


    public NavMeshAgent agent;

    void Update()
    {
        if (isActive)
        {
            BadGuyRay();
            PositionCalculators();
            Debug.DrawRay(ray.origin, playerPosition);
        }
        isActive = true;
    }

    public void BadGuyRay()
    {

        playerDistance = Vector3.Distance(transform.position, playerToLookFor.transform.position);

        //RaycastHit hit;
        ray = new Ray(this.transform.position, direction);//The ray being cast to the player's current position

        //Debug.Log("Stuff is: " + ray);

        if (Physics.Raycast(ray.origin, direction * sightRange, out hit, playerHit))//If the ray is hitting the player layer within the set range
        {
            Debug.LogWarning("Agent destination set");
            //agent.SetDestination(hit.point);
            agent.SetDestination(playerPosition);
            //playerPosition = hit.point; // sets v3 position to the hitpoint
            Debug.Log("I have hit something");
        }
    }
    
    public void PositionCalculators()
    {
        if (isLooking)
        {
            //Vector3 offset = new Vector3(0, 0.2f, 0);
            playerPosition = (playerToLookFor.transform.position);
            enemyPosition = (enemy.transform.position);

            direction = (playerPosition - enemyPosition).normalized;
        }
    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(playerPosition, radius: 0.2f);
    }
}
