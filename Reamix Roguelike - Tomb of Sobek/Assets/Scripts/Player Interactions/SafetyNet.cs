using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNet : MonoBehaviour
{
    [SerializeField]
    private CharacterController charac;
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (charac.transform.position.y < -2)
        {
            charac.velocity.Set(0, 0, 0);
            charac.transform.position = new Vector3(0, 1, 0);
        }
    }
}
