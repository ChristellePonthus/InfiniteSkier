using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Transform chunksContainer;
    public Transform collectableContainer;
    [SerializeField] private MainCharacterController characterController;


    void Update()
    {
        var velocity = characterController.currentSpeed * Time.deltaTime * Vector3.back;

        foreach (Transform child in chunksContainer)
            child.position += velocity;

        foreach (Transform child in collectableContainer)
            child.position += velocity;
    }
}
