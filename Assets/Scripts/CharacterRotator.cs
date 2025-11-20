using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Quaternion _lookRotation;
    public Quaternion LookRotation => _lookRotation;
    public void ProcessRotateTo(Vector3 direction)
    {
        _lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, step);
    }
}
