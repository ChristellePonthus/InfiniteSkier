using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Transform chunksContainer;
    public Transform collectableContainer;
    [SerializeField] private MainCharacterController characterController;


    void Update()
    {
        var velocity = Vector3.back * characterController.currentSpeed * Time.deltaTime;

        foreach (Transform child in chunksContainer)
            child.position += velocity;

        foreach (Transform child in collectableContainer)
            child.position += velocity;
    }
}
