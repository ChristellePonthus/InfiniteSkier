using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private float size = 6f;
    private float timer = 0f;
    [SerializeField] private float maxTime = 5f;
    [SerializeField] private float minTime = 2f;

    [SerializeField] private List<ObstacleData> obstacles = new List<ObstacleData>();
    [SerializeField] private Transform obstaclesContainer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (GameController.instance.currentLevel > 5)
        {
            maxTime = 3.5f;
        }

        if (timer >= Random.Range(minTime, maxTime))
        {
            timer = 0f;
            SpawnObstacles();
        }
    }
    private void SpawnObstacles()
    {
        Instantiate(PickRandomObstacles(), transform.position + new Vector3(Random.Range(-size * .5f, size * .5f), 0, 0), Quaternion.identity, obstaclesContainer);
    }

    private GameObject PickRandomObstacles()
    {
        return obstacles[Random.Range(0, obstacles.Count)].prefab;
    }
}
