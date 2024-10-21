using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int positionInArray;
    public float movSpeed = 0;
    public float health = 100;
    public float dmgToTowers = 0;
    public int id = 0;
    public NavMeshAgent navMesh;
    // 0 = Not Ready, 1 = Normal Enemy, 2 = Normal more hp, 3 = normal more moveSpeed, 4 = Splitting Enemy , 5 = Tank Enemy

    // Start is called before the first frame update
    void Start()
    {
        if(id != 0){
            navMesh = this.GetComponent<NavMeshAgent>();
            navMesh.speed = movSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
