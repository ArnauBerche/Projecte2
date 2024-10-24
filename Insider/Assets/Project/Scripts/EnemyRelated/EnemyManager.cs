using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public class Spawner
    {
        public Transform SP;
        public virtual void Spawn(GameObject prefab, Spawner spawner){}
        public void SetSP(Transform SpawnPointer)
        {
            SP = SpawnPointer;
        }
        public Transform GetRandomChild()
        {
            List<Transform> childs = new List<Transform>();
            foreach (Transform child in SP)
            {
                childs.Add(child);
            }
            int randomIndex = Random.Range(0, childs.Count);
            return childs[randomIndex];
        }
    }

    public abstract class EnemyStats : Spawner
    {
        //public int positionInArray;
        public string enemyName;
        public float movSpeed;
        public float health;
        public float dmg;
        public int economyGiven;
        public GameObject enemyObj;


        public abstract void SetEnemy();
        public override void Spawn(GameObject prefab, Spawner spawner)
        {
            enemyObj = prefab;
            Transform childcoords = spawner.GetRandomChild();
            enemyObj = Instantiate(enemyObj, childcoords.position, Quaternion.identity);
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





    //Get from LevelManager
    public string order;

    //EnemyManager vars
    private int amountNormal;
    private int amountRock;
    private int amountSpeedy;
    private int amountSplitter;
    private int amountTank;
    public int amountToSpawn = 0;
    public List<EnemyStats> allEnemys;

    public Spawner sp;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    public void Awake()
    {
        sp = new Spawner();
        sp.SetSP(GetComponent<Transform>().Find("-Spawner"));
        allEnemys = new List<EnemyStats>();
    }
    void Start()
    {
        order = "12345";      
        InitializeAndStoreEnemiesInOrder();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeAndStoreEnemiesInOrder()
    {
        foreach (char c in order)
        {
            switch(c)
            {
                case '1':
                        EnemyStats normalHolder = new Normal();
                        normalHolder.SetEnemy();
                        allEnemys.Add(normalHolder);
                    break;
                case '2':
                        EnemyStats rockHolder = new Rock();
                        rockHolder.SetEnemy();
                        allEnemys.Add(rockHolder);
                    break;
                case '3':
                        EnemyStats SpeedyHolder = new Speedy();
                        SpeedyHolder.SetEnemy();
                        allEnemys.Add(SpeedyHolder);
                    break;
                case '4':
                        EnemyStats SplitterHolder = new Splitter();
                        SplitterHolder.SetEnemy();
                        allEnemys.Add(SplitterHolder);
                    break;
                case '5':
                        EnemyStats TankHolder = new Tank();
                        TankHolder.SetEnemy();
                        allEnemys.Add(TankHolder);
                    break;
                default:
                    Debug.Log("Character out of bounds: " + c);
                    amountToSpawn--;
                    break;

            }
            amountToSpawn++;
        }
    }

    void SpawnEnemies()
    {
        for (int x = 0; x < amountToSpawn; x++)
        {
            allEnemys[x].Spawn(enemyPrefab,sp);
        }
    }
}
