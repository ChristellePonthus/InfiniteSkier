using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField] private float size = 6f;

    private float timer = 0f;
    [SerializeField] private float maxTime = 5f;
    [SerializeField] private float minTime = 2f;

    [SerializeField] private List<GameObject> collectables = new List<GameObject>();
    [SerializeField] private Transform collectablesContainer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (GameController.instance.currentLevel > 5)
        {
            maxTime = 4;
        }

        if (timer >= Random.Range(minTime, maxTime))
        {
            timer = 0f;
            SpawnCollectables();
        }
    }

    private void SpawnCollectables()
    {
        Instantiate(PickRandomCollectable(), transform.position + new Vector3(Random.Range(-size * .5f, size * .5f), 0, 0), Quaternion.identity, collectablesContainer);
    }

    private GameObject PickRandomCollectable()
    {
        return collectables[Random.Range(0, collectables.Count)];
    }

 }
