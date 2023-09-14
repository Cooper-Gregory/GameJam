using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Raytest : MonoBehaviour
{

    public GameObject lastHit;
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;

    void Update()
    {
        
    }


    void tester()
    {
        Ray ray = new Ray (this.transform.position, this.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collision, radius: 0.2f);
    }

}
