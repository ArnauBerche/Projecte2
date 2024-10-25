using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SP;
    List<Child> childs = new List<Child>();
    public Spawner(Transform spawnPointer)
    {
        SetSP(spawnPointer);
        foreach (Transform child in SP)
        {
            Child childHolder;
            childHolder = new Child(child);
            childHolder.SetSpawnable(true);
            childs.Add(childHolder);
        }
    }
    public void SetSP(Transform spawnPointer)
    {
        SP = spawnPointer;
    }
    public Child GetRandomChild()
    {
        int randomIndex = Random.Range(0, childs.Count);
        return childs[randomIndex];
    }

    public Child GetLeastCoolDownChild()
    {
        int counter = 0;
        int giveChildNum = 0;
        float lowestCooldown = 0.0f;
        foreach(Child c in childs)
        {
            if(c.cooldown <= 0)
            {
                giveChildNum = counter;
                break;
            }
            else
            {
                if(c.cooldown <= lowestCooldown)
                {
                    lowestCooldown = c.cooldown;
                    giveChildNum = counter;
                }
            }

            counter++;
        }
        return childs[giveChildNum];
    } 
}

public class Child
{
    public Transform transformChild;
    public bool isSpawnable = true;
    public float cooldown = 1.0f;

    public Child(Transform Transform)
    {
        transformChild = Transform;
    }

    public void SetSpawnable(bool canSpawn)
    {
        isSpawnable = canSpawn;
    }

}