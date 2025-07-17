using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerSpawnAndPool : MonoBehaviour
{
    public static ManagerSpawnAndPool instance;

    public GameObject gridPrefab;
    public GameObject heroPrefab;
    public GameObject enemyPrefab;
    public GameObject portalEnemyPrefab;
    public GameObject bulletPrefab;

    public GameObject sunFlowerPrefab;
    public GameObject sunPrefab;

    /* ========== Part of container ========== */
    public Transform gridContainer;
    public Transform heroContainer;
    public Transform enemyContainer;
    public Transform portalEnemyContainer;
    public Transform bulletContainer;

    public Transform sunFlowerContainer;
    public Transform sunContainer; 

    /* ========== Part of Pool ========== */
    public List<GameObject> poolEnemy = new List<GameObject>();
    public List<GameObject> poolBullet = new List<GameObject>();
    public List<GameObject> poolGrid = new List<GameObject>();
    public List<GameObject> poolHero = new List<GameObject>();
    public List<GameObject> poolPortalEnenmy = new List<GameObject>();

    public List<GameObject> poolSunFlower = new List<GameObject>();
    public List<GameObject> poolSun = new List<GameObject>();

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    private void Start()
    {
        SpawnObj(gridPrefab, gridContainer, poolGrid, 50);
        SpawnObj(bulletPrefab,bulletContainer,poolBullet,10);
        SpawnObj(enemyPrefab, enemyContainer, poolEnemy, 20);
        SpawnObj(heroPrefab, heroContainer, poolHero, 20);
        SpawnObj(portalEnemyPrefab, portalEnemyContainer, poolPortalEnenmy, 5);
        SpawnObj(sunPrefab, sunContainer, poolSun, 10);
        SpawnObj(sunFlowerPrefab,sunFlowerContainer, poolSunFlower, 10);
    }

    public void SpawnObj(GameObject objPrefab, Transform objContainer, List<GameObject> pool,int value)
    { 
        for(int i = 0; i < value; i++)
        {
            GameObject obj = Instantiate(objPrefab);
            pool.Add(obj);
            obj.transform.parent = objContainer;
            obj.SetActive(false);
        }
       
    }
}
