using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private float lifePointsRemoved;
    public ObstacleData _obstacleData;
    private Rigidbody _rb;


    private void OnTriggerEnter(Collider other)
    {
        MainCharacterController mainCharacter = other.GetComponent<MainCharacterController>();
        _rb = GetComponent<Rigidbody>();

        if (mainCharacter)
        {
            lifePointsRemoved = _obstacleData.damages;
            mainCharacter.RemoveLifePoints(lifePointsRemoved);
            _rb.AddForce(Vector3.up * 12f, ForceMode.Acceleration);
        }
    }
}
