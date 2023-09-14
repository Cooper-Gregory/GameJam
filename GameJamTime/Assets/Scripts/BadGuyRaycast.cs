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
    public float raycastRange = 100;


    public NavMeshAgent agent;

    void Start()
    {
        
    }


    void Update()
    {

        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastRange, playerHit))
        {
            agent.SetDestination(hit.point);
            collision = hit.point; // sets v3 position to the hitpoint
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, radius: 0.2f);
    }
}
