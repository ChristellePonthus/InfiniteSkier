using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] private float lifePoints = 10f;
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        MainCharacterController mainCharacter = other.GetComponent<MainCharacterController>();

        foreach (GameObject obstacle in obstacles)
        {
            if (mainCharacter)
            {
                mainCharacter.RemoveLifePoints(lifePoints);
            }
        }
    }
}
