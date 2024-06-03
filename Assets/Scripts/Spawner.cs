using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform chunksContainer;
    public List<GameObject> chunks;
    private void OnTriggerExit(Collider other)
    {
        Transform lastChunkEnd = other.gameObject.transform.Find("ChunckEnd");
        Instantiate(PickRandomChunk(), lastChunkEnd.position, Quaternion.identity, chunksContainer);
    }

    private GameObject PickRandomChunk()
    {
        int rndIndex = Random.Range(0, chunks.Count);
        return chunks[rndIndex];
    }
}
