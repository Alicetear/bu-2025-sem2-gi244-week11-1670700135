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
            int totalSpawnEnemies = 0;
            int numberOfRandomSpawnPoint = 0;
            float delayStart = 0f;
            float spawnInterval = 0f;
            int numberOfPowerUp = 0;

            if (wave == 1)
            {
                totalSpawnEnemies = 4;
                numberOfRandomSpawnPoint = 1;
                delayStart = 2f;
                spawnInterval = 2.0f;
                numberOfPowerUp = 0;
            }
            else if (wave == 2)
            {
                totalSpawnEnemies = 6;
                numberOfRandomSpawnPoint = 2;
                delayStart = 2f;
                spawnInterval = 2.0f;
                numberOfPowerUp = 1;
            }
            else if (wave == 3)
            {
                totalSpawnEnemies = 8;
                numberOfRandomSpawnPoint = 4;
                delayStart = 2f;
                spawnInterval = 2.0f;
                numberOfPowerUp = 1;
            }
            else if (wave == 4)
            {
                totalSpawnEnemies = 10;
                numberOfRandomSpawnPoint = 6;
                delayStart = 5f;
                spawnInterval = 0.5f;
                numberOfPowerUp = 2;
            }

            Debug.Log("Wave " + wave + " START");

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

            Debug.Log("Wave " + wave + " END");
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
            temp.RemoveAt(rand);
        }

        return result;
    }
}
