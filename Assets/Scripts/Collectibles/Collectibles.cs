using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private float amount = 10f;
    [SerializeField] private GameObject fx;
    private void OnTriggerEnter(Collider other)
    {
        MainCharacterController mainCharacter = other.GetComponent<MainCharacterController>();
        if (mainCharacter)
        {
            if (fx != null)
            {
                var newFX = Instantiate(fx, mainCharacter.transform);
                Destroy(newFX, 1f);
            }
            mainCharacter.AddPoints(amount);
            Destroy(this.gameObject);
        }
    }
}
