using UnityEngine;

public class SurfSoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private MainCharacterController _mainCharacterController;

    [SerializeField] private float maxVolume = 0.5f;
    [SerializeField] private float maxPitch = 0.5f;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _mainCharacterController = GetComponent<MainCharacterController>();
    }

    void Update()
    {
        var speedFactor = _mainCharacterController.currentSpeed / _mainCharacterController.maxSpeed;
        _audioSource.volume = speedFactor * maxVolume;
        _audioSource.pitch = speedFactor * maxPitch;
    }
}
