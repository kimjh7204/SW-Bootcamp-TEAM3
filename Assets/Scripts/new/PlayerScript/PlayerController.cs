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
    [SerializeField] private ParticleSystem clickParticlePrefab;

    private static NavMeshAgent staticAgent;

    private static bool _playerCanMove;
    public static bool playerCanMove
    {
        get => _playerCanMove;
        set
        {
            staticAgent.isStopped = !value;
            _playerCanMove = value;
            staticAgent.ResetPath();
        }
    }

    enum States
    {
        Walking = 1,
        Idle = 5
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        staticAgent = agent;
        playerCanMove = true;
    }

    void Update()
    {
        UpdateState();

        /*// For NavData Test
        if (playerCanMove)
            Debug.Log("true");
        else if (!playerCanMove)
            Debug.Log("false");*/
        Debug.Log(GameData.playerCollisionState);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetMouseButtonDown(0) && playerCanMove)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
               
                CreateClickParticle(hit.point);
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
    
    private void CreateClickParticle(Vector3 position)
    {
        if (clickParticlePrefab != null)
        {
            ParticleSystem particle = Instantiate(clickParticlePrefab, position, Quaternion.identity);
            Destroy(particle.gameObject, 0.5f);
        }
    }
    
}


