using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Outline>()) return;
        GetComponent<Outline>().OutlineWidth = other.gameObject.GetComponent<Outline>().OutlineWidth;
        Destroy(other.gameObject);
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_destination);
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
        {
            _destination = hit.point;
        }
    }
}