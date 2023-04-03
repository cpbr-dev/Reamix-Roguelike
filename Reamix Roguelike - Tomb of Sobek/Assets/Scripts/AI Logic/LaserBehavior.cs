using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public float laserWidth = 0.05f;
    public float maxLength = 50;
    public Transform startPoint;
    public Transform endPoint;
    public LayerMask obstacles = 0;
    public int playerLayer = 8;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        UpdateLineRenderer();
    }

    private void Update()
    {
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        line.positionCount = 2;
        line.SetPosition(0, startPoint.localPosition);
        line.SetPosition(1, endPoint.localPosition);
        line.widthMultiplier = laserWidth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(startPoint.position, transform.forward, out hit, maxLength,obstacles);
        if(hasHit)
        {
            endPoint.position = hit.point;
            if(hit.transform.gameObject.layer == playerLayer)
            {
                GuardBehavior[] guards = FindObjectsOfType<GuardBehavior>();
                Vector3 groundPosition = hit.point;

                //Shoot another ray towards the ground to better set the source position.
                hasHit = Physics.Raycast(hit.point, Vector3.down, out hit, maxLength, obstacles);
                
                if (hasHit)
                    groundPosition = hit.point;

                foreach (var item in guards)
                {
                    item.ForceChasing(groundPosition);
                }
            }
        }
        else
        {
            endPoint.position = startPoint.position + transform.forward * maxLength;
        }
    }
}
