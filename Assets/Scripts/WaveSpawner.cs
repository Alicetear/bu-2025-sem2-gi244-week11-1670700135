using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (int wave = 1; wave <= 4; wave++)
        {
            int totalSpawnEnemies = 4 + (wave - 1) * 2;

            int numberOfRandomSpawnPoint = (wave == 3) ? 4 : wave;

            float delayStart = 2f;
            float spawnInterval = 2f;
            int numberOfPowerUp = (wave == 1) ? 0 : 1;

            List<Transform> selectedPoints = GetRandomPoints(numberOfRandomSpawnPoint);

            for (int i = 0; i < numberOfPowerUp; i++)
            {
                int rand = Random.Range(0, selectedPoints.Count);
                Instantiate(powerUpPrefab, selectedPoints[rand].position, Quaternion.identity);
            }

            yield return new WaitForSeconds(delayStart);

            for (int i = 0; i < totalSpawnEnemies; i++)
            {
                int rand = Random.Range(0, selectedPoints.Count);
                Instantiate(enemyPrefab, selectedPoints[rand].position, Quaternion.identity);

                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitUntil(() =>
                GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length == 0
            );
        }
    }

    List<Transform> GetRandomPoints(int count)
    {
        List<Transform> temp = new List<Transform>(spawnPoints);
        List<Transform> result = new List<Transform>();

        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, temp.Count);
            result.Add(temp[rand]);
            temp.RemoveAt(rand); // ??????
        }

        return result;
    }
}
