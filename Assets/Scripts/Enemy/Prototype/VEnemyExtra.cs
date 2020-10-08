using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VEnemyExtra : MonoBehaviour
{
    public GameObject visionExample = null;
    Vision visioner = null;

    public MeshRenderer cylinder;

    public Material unseenMat;
    public Material spottedMat;

    private void Awake()
    {
        visioner = visionExample.GetComponent<Vision>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (visioner.TargetInside(transform))
        {
            // Shoot ray to visioner
            //Ray ray = new Ray(transform.position, -visioner.transform.forward);
            Ray ray = new Ray(transform.position, (visioner.transform.position - transform.position).normalized);
            //Debug.DrawLine(transform.position, -visioner.transform.forward * visioner.radius);
            Debug.DrawLine(transform.position, (visioner.transform.position - transform.position) * visioner.radius);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, visioner.radius, LayerMask.GetMask("Agent")))
            {
                Debug.DrawLine(transform.position,  hit.point, Color.red);
                if (hit.collider.tag == "Player")
                {
                    cylinder.material = spottedMat;
                }
                //cylinder.material = spottedMat;
            }
        }
        else
        {
            cylinder.material = unseenMat;
        }
    }
}

