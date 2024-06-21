using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Transform chunksContainer;
    public Transform collectableContainer;
    public Transform obstaclesContainer;
    
    public void Forward(Vector3 velocity)
    {
        foreach (Transform child in chunksContainer)
            child.position += velocity;

        foreach (Transform child in collectableContainer)
            child.position += velocity;

        foreach (Transform child in obstaclesContainer)
            child.position += velocity;
    }

}
