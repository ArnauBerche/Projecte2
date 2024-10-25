using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStats
    {
        //public int positionInArray;
        public string enemyName;
        public float movSpeed;
        public float health;
        public float dmg;
        public int economyGiven;
        public GameObject enemyObj;


        public abstract void SetEnemy();
        public void Spawn(GameObject prefab, Spawner spawner)
        {
            enemyObj = prefab;
            Child childcoords = spawner.GetRandomChild();
            enemyObj = Spawner.Instantiate(enemyObj, childcoords.transformChild.position, Quaternion.identity);
            enemyObj.GetComponent<Enemy>().SetEnemyData(this);
        }

    }

    class Normal : EnemyStats
    {
        public override void SetEnemy()
        {
            enemyName = "IgA";
            movSpeed = 1.0f;
            health = 100.0f;
            dmg = 10.0f;
            economyGiven = 10;
        }
    }
    
    class Rock : EnemyStats
    {
        public override void SetEnemy()
        {
            enemyName = "IgD";
            movSpeed = 1.25f;
            health = 150.0f;
            dmg = 10.0f;
            economyGiven = 20;
        }
    }
    
    class Speedy : EnemyStats
    {
        public override void SetEnemy()
        {
            enemyName = "IgE";
            movSpeed = 1.5f;
            health = 125.0f;
            dmg = 10.0f;
            economyGiven = 20;
        }
    }
    
    class Splitter : EnemyStats
    {
        public override void SetEnemy()
        {
            enemyName = "IgG";
            movSpeed = 1.0f;
            health = 150.0f;
            dmg = 10.0f;
            economyGiven = 10;
        }

        public void Split()
        {

        }
    }
    
    class Tank : EnemyStats
    {
        public override void SetEnemy()
        {
            enemyName = "IgM";
            movSpeed = 0.5f;
            health = 500.0f;
            dmg = 10.0f;
            economyGiven = 60;
        }
    }
