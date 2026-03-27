using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        //InvokeRepeating(nameof(RandomSpawn), 0, 5);
    }

    void RandomSpawn()
    {
        var index = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }


    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3);
        }

        //IEnumerator Goodbye()
        //{
        //    while (true)
        //    {
        //        Debug.Log("Bye" + Time.frameCount + "" + Time.time);
        //        yield return null;

        //        yield return Hello();
        //    }
        //}
        //IEnumerator Hello()
        //{
        //    Debug.Log("Hello" + Time.deltaTime);
        //    yield return null;
        //}


    }
}
