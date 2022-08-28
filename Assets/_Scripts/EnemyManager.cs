using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Target")] 
    [SerializeField] private GameObject player;

    [Header("References")] 
    [SerializeField] private EnemyPooler enemyPooler;


    [Header("Zone One SpawnLocations")]
    [SerializeField] private Transform zoneOneCircleSpawnLoc;
    [SerializeField] private Transform zoneOneSquareSpawnLoc;
    
    

    [Header("Settings")] 
    [SerializeField] private int spawnAmount;

    [SerializeField] private float ySpawnPosition;


    private int currentSpawnCount;


    private int currentZone;
    


    void Start()
    {
        currentZone = 1;
        PrepEnemy(SpawnEnemiesInACircle(zoneOneCircleSpawnLoc.transform.position, 12, 3));
    }

    private List<Enemy> SpawnEnemiesInACircle(Vector3 pos, int amountToSpawn, float radius)
    {
        
        var spawnedEnemies = new List<Enemy>();
        
        for (int i = 0; i < amountToSpawn; i++)
        {
            float angle = i * Mathf.PI*2f / amountToSpawn;
            pos.y = 0;
            Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, ySpawnPosition, Mathf.Sin(angle)*radius);
            var spawnedEnemy = enemyPooler.SpawnFromPool(newPos + pos, Quaternion.identity);

            spawnedEnemies.Add(spawnedEnemy);
        }

        return spawnedEnemies;
    }

    private void SpawnEnemiesInASquare()
    {
        
    }

    private void PrepEnemy(List<Enemy> spawnedEnemies)
    {
        foreach (var enemy in spawnedEnemies)
        {
            enemy.Initialize(player.transform, this);
            currentSpawnCount++;
        }
    }

    private void ZoneCompleted()
    {
        switch (currentZone)
        {
            case 1:
                EventsManager.Instance.ZoneOneCompleted();
                break;
            case 2:
                EventsManager.Instance.ZoneTwoCompleted();
                break;
            case 3:
                EventsManager.Instance.ZoneThreeCompleted();
                break;
        }
    }

    public void EnemyDisabled()
    {
        currentSpawnCount--;

        if (currentSpawnCount <= 0)
        {
            ZoneCompleted();
        }
    }


}
