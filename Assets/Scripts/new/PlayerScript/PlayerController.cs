using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Animator ani;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent < Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && NavData.playerCanMove)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point) ;
                ani.SetBool("Walking" , true);
            }
            
        }
        else ani.SetBool("Walking" , false);
    }
}
