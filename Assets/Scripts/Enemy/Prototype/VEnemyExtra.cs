using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            cylinder.material = spottedMat;
        }
        else
        {
            cylinder.material = unseenMat;
        }
    }
}

