using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] Transform finaltarget;

    NavMeshAgent agent;
    [SerializeField] Transform currentTarget;
    [SerializeField] int currentTargetNum = 0;
    [SerializeField] int chosen;
    [SerializeField] Transform[] path1;
    [SerializeField] Transform[] path2;
    [SerializeField] Transform[] pathList;


    void Start()
    {
        if (chosen == 0)
        {
            pathList = path2;
        }
        else 
        {
            pathList = path1;
        }
 
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentTarget = pathList[currentTargetNum];
    }

    void Update()
    {
        agent.SetDestination(currentTarget.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == currentTarget) {
            currentTargetNum++;
            if (currentTargetNum == pathList.Length)
            {
                currentTarget = finaltarget;
            }
            else
            {
                currentTarget = pathList[currentTargetNum];
            }

        }
    }
}
