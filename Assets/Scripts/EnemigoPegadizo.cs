using UnityEngine;

public class EnemigoPegadizo : MonoBehaviour
{
    private bool _pegado = false;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _pegado = true;
            transform.parent = collision.transform;
            _rb.isKinematic = true;
        }
    }

    void FixedUpdate()
    {
        if (_pegado)
        {
            transform.position = transform.parent.position;
        }
    }
}
