using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainCharacterController : MonoBehaviour
{
    [SerializeField] public float maxSpeed { get; private set; } = 10f;
    [SerializeField] private float targetSpeed = 10f;
    [SerializeField] private float targetMoveSpeed = 10f;
    [SerializeField] private float limits = 4f;
    [SerializeField] private Transform character;
    [SerializeField] private bool demoMode = false;
    [SerializeField] private float maxLife = 1000f;
    
    private float _currentMoveSpeed = 0f;
    private Vector3 _currentDirection = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;
    private Animator _animator;
    private float maxPoints = 1000f;

    public float currentSpeed { get; private set; } = 0f;
    public float currentLife = 1000f;
    public float currentPoints = 0f;
    public Vector3 targetDirection;
    
    public UnityEvent<float> onSetLifepoints;
    public UnityEvent<float> onSetMaxLifePoints;
    public UnityEvent<float> onSetPoints;
    public UnityEvent<Vector3> onSetVelocity;

    private void Start()
    {
        if (!demoMode)
        {
            currentLife = maxLife;
            onSetMaxLifePoints.Invoke(maxLife);
            targetSpeed = maxSpeed;
            _animator = GetComponentInChildren<Animator>();
        }
    }


    private void Update()
    {
        currentSpeed = targetSpeed;

        if (!demoMode)
        {
            Move();
            onSetLifepoints.Invoke(currentLife);
        }
    }

    private void Move()
    {
        var velocity = currentSpeed * Time.deltaTime * Vector3.back;
        onSetVelocity.Invoke(velocity);
        _currentDirection = GetInputDirection();
        _currentMoveSpeed = targetMoveSpeed;
        transform.Translate(_currentMoveSpeed * Time.deltaTime * _currentDirection);
    }

    private Vector3 GetInputDirection()
    {
        targetDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
            targetDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            targetDirection += Vector3.right;

        if (transform.position.x >= limits)
            targetDirection = Vector3.left;
        if (transform.position.x <= -limits)
            targetDirection = Vector3.right;

        return targetDirection;
    }

    public void AddPoints(float points)
    {
        if (!demoMode) {
            currentPoints += points;
            if (currentPoints > GameController.instance.currentLevel * GameController.instance.pointsToLvlUp)
            {
                GameController.instance.LevelUp();
                Debug.Log($"Level Up {GameController.instance.currentLevel}");
                maxSpeed += maxSpeed * 0.2f;
                targetSpeed = maxSpeed;
            }
            onSetPoints.Invoke(currentPoints);
            onSetLifepoints.Invoke(currentLife);
            if (currentPoints >= maxPoints && currentLife > 0f)
            {
                _animator.SetBool("victory", true);
                _animator.SetBool("defeat", false);
                SceneManager.LoadScene("Victory");
                _animator.Play("Base Layer.Victory_hip_hop",0,0);
                _currentDirection = Vector3.zero;
                targetSpeed = 0f;
            }
            GameController.instance.SetPoints(points);
        }
    }

    public void RemoveLifePoints(float lifepoints)
    {
        if (!demoMode)
        {
            currentLife -= lifepoints;
            onSetLifepoints.Invoke(currentLife);
            if (_currentDirection.x <= 0f)
            {
                _currentDirection = Vector3.right;
                character.position = Vector3.SmoothDamp(_currentDirection, targetDirection, ref _velocity, 1f);
            }
            else if (_currentDirection.x >= 0f)
            {
                _currentDirection = Vector3.left;
                _velocity *= -1;
                character.position = Vector3.SmoothDamp(_currentDirection, targetDirection, ref _velocity, 1f); ;
            }
            if (currentLife <= 0f)
            {
                _animator.SetBool("defeat", true);
                _animator.SetBool("victory", false);
                _animator.Play("Base Layer.Defeat_idle",0,0);
                SceneManager.LoadScene("GameOver");
                _currentDirection = Vector3.zero;
                targetSpeed = 0f;
            }
        GameController.instance.SetLifePoints(lifepoints);
        }
    }

}
