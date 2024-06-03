using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private float lifePointsRemoved = 10f;

    private void OnTriggerEnter(Collider other)
    {
        MainCharacterController mainCharacter = other.GetComponent<MainCharacterController>();

        if (mainCharacter)
        {
            mainCharacter.RemoveLifePoints(lifePointsRemoved);
        }
    }
}
