using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    [SerializeField] private Fire _fire;
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<Outline>().OutlineWidth != 2)
        {
            Break();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _fire.ActivateObject();
        }
    }

    private void Break()
    {
        _navMeshObstacle.enabled = true;
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
            var forceValue = Random.Range(_minForceValue, _maxForceValue);
            var direction = Random.insideUnitSphere;
            rigidbody.AddForce(direction * forceValue);
        }
    }
}