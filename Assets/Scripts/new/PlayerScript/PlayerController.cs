using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    Animator animator;
    string animationState = "AnimationState";

    enum States
    {
        Walking = 1,
        Idle = 5
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetMouseButtonDown(0) && NavData.playerCanMove)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void UpdateState()
    {
        if (agent.velocity.magnitude > 0)
        {
            // 움직이고 있을 때 "Walking" 애니메이션 실행
            animator.SetInteger(animationState, (int)States.Walking);
        }
        else
        {
            // 움직이지 않을 때 "Idle" 애니메이션 실행
            animator.SetInteger(animationState, (int)States.Idle);
        }
    }

}