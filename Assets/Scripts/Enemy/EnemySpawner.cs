using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Juicy2DShooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       21-01-2023 14:02:42
================================================*/ 
public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private List<GameObject> spawnPoints = null;
    [SerializeField]
    private int count = 20;
    [SerializeField]
    private float minDelay = 0.8f, maxDelay = 1.5f;

    IEnumerator SpawnCoroutine() {
        while(count > 0) {
            count--;
            var randomIndex = Random.Range(0, spawnPoints.Count);
            var randomOffset = Random.insideUnitCircle;
            var spawnPoint = spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;
            SpawnEnemy(spawnPoint);
            var randomTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private void SpawnEnemy(Vector3 spawnPoint) {
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }

    private void Start() {
        if(spawnPoints.Count > 0) {
            foreach (var point in spawnPoints) {
                SpawnEnemy(point.transform.position);
            }
        }
        StartCoroutine(SpawnCoroutine());
    }
}