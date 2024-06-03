using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform chunksContainer;
    public Transform collectableContainer;


    void Update()
    {
        var velocity = Vector3.back * speed * Time.deltaTime;

        foreach (Transform child in chunksContainer)
            child.position += velocity;

        foreach (Transform child in collectableContainer)
            child.position += velocity;
    }
}
