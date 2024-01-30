using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private Outline _outline;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Open();
        }
        
    }
    private void Open()
    {
        _animator.SetTrigger("open");
    }
}