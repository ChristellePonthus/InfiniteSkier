using UnityEngine;
using UnityEngine.Events;

public class MainCharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float limits = 3f;

    [SerializeField] private Transform character;
    [SerializeField] private bool demoMode = false;

    private Vector3 _currentDirection = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    private float currentLife = 0f;
    private float maxLife = 100f;
    private float currentPoints = 0f;

    [SerializeField] private LifeBar lifeBar;

    public UnityEvent<float> onSetLifepoints;
    public UnityEvent<float> onSetPoints;


    private void Start()
    {
        currentLife = maxLife;
        lifeBar.SetMaxLifepoints(maxLife);
    }


    void Update()
    {
        Vector3 targetDirection = Vector3.zero;

        /*if (demoMode)
            return targetDirection;*/

        if (Input.GetKey(KeyCode.A))
        {
            targetDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetDirection += Vector3.right;
        }

        if (transform.position.x >= limits)
        {
            targetDirection = Vector3.left;
        }
        if (transform.position.x <= -limits)
        {
            targetDirection = Vector3.right;
        }

        /*_currentDirection = Vector3.SmoothDamp(_currentDirection, targetDirection, ref _velocity, .8f);*/
        _currentDirection = targetDirection;

        transform.Translate(moveSpeed * Time.deltaTime * _currentDirection);

        lifeBar.SetLifepoints(currentLife);

    }

    public void AddLifePoints(float lifepoints)
    {
        currentLife += lifepoints;
        lifeBar.SetLifepoints(currentLife);
    }

    public void AddPoints(float points)
    {
        currentPoints += points;
        onSetPoints.Invoke(currentPoints);
    }

    public void RemoveLifePoints(float lifepoints)
    {
        currentLife -= lifepoints;
        lifeBar.SetLifepoints(currentLife);
    }
}
