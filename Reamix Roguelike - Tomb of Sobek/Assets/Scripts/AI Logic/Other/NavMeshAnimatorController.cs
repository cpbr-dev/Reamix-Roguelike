using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAnimatorController : MonoBehaviour
{
    public float globalAnimationSpeed = 1;
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();     
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = globalAnimationSpeed;
        if(!agent || agent.isStopped)
            animator.SetFloat("Speed", 0);
        else
            animator.SetFloat("Speed", agent.speed);
    }
}
