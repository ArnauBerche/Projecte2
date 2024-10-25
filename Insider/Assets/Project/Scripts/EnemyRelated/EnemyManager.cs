using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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

    private Spawner sp;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    public void Awake()
    {
        sp = new Spawner(GetComponent<Transform>().Find("-Spawner"));
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

    bool ReadyToSpawn()
    {
        return true;
    }

    
}
