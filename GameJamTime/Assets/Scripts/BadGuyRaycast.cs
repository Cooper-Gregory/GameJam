using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuyRaycast : MonoBehaviour
{

    [Header("Player Info")]
    public GameObject playerToLookFor;
    public Vector3 playerPosition;

    [Header("Enemy")]
    public GameObject enemy;
    public Vector3 enemyPosition;

    [Header("Raycast Info")]
    public LayerMask layerToTarget;
    public float sightRange;
    public float playerDistance;
    public Vector3 direction;
    private RaycastHit hit;
    public Ray ray = new Ray();
    public Vector3 offset;

    public bool canSeePlayer = true;
    public bool canNotSeePlayer = false;
    bool isActive = false;

    [Header("Move to sound")]
    public Vector3 audioSourcePosition;
    private BottleShatter[] bottles;


    public NavMeshAgent agent;

    void Update()
    {
        bottles = FindObjectsOfType<BottleShatter>();
        

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
        ray = new Ray(this.transform.position, direction);//The ray being cast to the player's current position

        if (Physics.Raycast(ray.origin, direction * sightRange, out hit, layerToTarget))//If the ray is hitting the player layer within the set range
        {

            agent.SetDestination(playerPosition);

            /*if (hit.collider.tag == "Player")
            {
                canSeePlayer = true;
                canNotSeePlayer = false;
                agent.SetDestination(playerPosition);
                //Debug.LogWarning("I can see you");
            }
            else if(hit.collider.tag == "Wall")
            {
                canSeePlayer = false;
                canNotSeePlayer = true;
                agent.SetDestination(this.transform.position);
                //Debug.Log("I can't see you anymore");
            }*/
        }
    }
    
    public void PositionCalculators()
    {
        playerPosition = (playerToLookFor.transform.position);
        enemyPosition = (enemy.transform.position);
        direction = (playerPosition - enemyPosition).normalized;
    }

    public void GoToSound()
    {

    }
}
