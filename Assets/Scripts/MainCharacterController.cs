using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{
    public float targetSpeed = 10f;
    public float currentSpeed = 0f;

    public float targetMoveSpeed = 10f;
    public float currentMoveSpeed = 0f;
    
    [SerializeField] private float limits = 3f;

    [SerializeField] private Transform character;
    [SerializeField] private bool demoMode = false;

    private Vector3 _currentDirection = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    public float currentLife = 0f;
    private float maxLife = 100f;
    public float currentPoints = 0f;

    [SerializeField] private LifeBar lifeBar;

    public UnityEvent<float> onSetLifepoints;
    public UnityEvent<float> onSetPoints;


    private void Start()
    {
        if (!demoMode)
        {
            currentLife = maxLife;
            lifeBar.SetMaxLifepoints(maxLife);
        }
    }


    void Update()
    {
        Vector3 targetDirection = Vector3.zero;
        currentSpeed = targetSpeed;

        if (!demoMode)
        {
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
            currentMoveSpeed = targetMoveSpeed;

            transform.Translate(currentMoveSpeed * Time.deltaTime * _currentDirection);

            lifeBar.SetLifepoints(currentLife);
        }
    }

    public void AddPoints(float points)
    {
        if (!demoMode) {
            currentPoints += points;
            onSetPoints.Invoke(currentPoints);
        }
    }

    public void RemoveLifePoints(float lifepoints)
    {
        if (!demoMode)
        {
            currentLife -= lifepoints;
            lifeBar.SetLifepoints(currentLife);
            character.position = Vector3.zero;
            targetSpeed = 10;
            if (currentLife <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
