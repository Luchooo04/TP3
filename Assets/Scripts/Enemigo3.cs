using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;

    private Rigidbody rb;
    private Transform player;
    private bool detectedPlayer = false;
    [SerializeField] private float rangoDeteccion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (!detectedPlayer)
        {
            RaycastHit informacionSuelo;
            if (Physics.Raycast(controladorSuelo.position, Vector3.down, out informacionSuelo, distancia))
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);
            }
            else
            {
                Girar();
            }
        }
        else
        {
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            if (targetPosition.x < transform.position.x)
            {
                velocidad = -Mathf.Abs(velocidad);
            }
            else
            {
                velocidad = Mathf.Abs(velocidad);
            }

            rb.velocity = (targetPosition - transform.position).normalized * velocidad;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < rangoDeteccion)
        {
            detectedPlayer = true;
        }
    }

    private void Girar()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (controladorSuelo != null)
        {
            Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
