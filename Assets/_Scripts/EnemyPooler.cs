using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject enemyContaier;
    

    [Header("Settings")] 
    [SerializeField] private int initalSize;
    
    [SerializeField] private Queue<Enemy> enemyPool;
    void Start()
    {
        enemyPool = new Queue<Enemy>();

        for (int i = 0; i < initalSize; i++)
        {
            var go = Instantiate(enemy, enemyContaier.transform);
            go.SetActive(false);
            enemyPool.Enqueue(go.GetComponent<Enemy>());
        }
    }

    public Enemy SpawnFromPool(Vector3 pos, Quaternion rot)
    {
        var objectToSpawn = enemyPool.Dequeue();

        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;
        objectToSpawn.gameObject.SetActive(true);
        
        enemyPool.Enqueue(objectToSpawn);

        return objectToSpawn;
    }


}
