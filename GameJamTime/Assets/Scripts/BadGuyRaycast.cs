using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuyRaycast : MonoBehaviour
{

    //public GameObject lastHit;
    public Vector3 collision = Vector3.zero;

    //[Header("Layers")]
    public LayerMask playerHit;
    //public LayerMask wallHit;
    public LayerMask ground;
    public float raycastRange = 100;


    public NavMeshAgent agent;

    void Start()
    {
        
    }


    void Update()
    {
        BadGuyRay();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collision, radius: 0.2f);
    }

    public void BadGuyRay()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(this.transform.position, fwd);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, raycastRange, playerHit))
        {
            agent.SetDestination(hit.point);
            collision = hit.point; // sets v3 position to the hitpoint
            Debug.Log("I have hit something");


        }

        if (Physics.Raycast(ray, out hit, ground))
        {
            Debug.LogWarning("Hitting the ground!!");
        }
    }
}
