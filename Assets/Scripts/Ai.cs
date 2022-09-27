using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    private NavMeshAgent agent;
    public float radius;
    private float timer = 5;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (!agent.hasPath)
        {
            
            agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, radius));
        }
        if(agent.transform.position != agent.destination && timer == 0 ) {
            agent.SetDestination(GetPoint.Instance.GetRandomPoint(transform, radius));
            timer = 5;
        }
    }


}