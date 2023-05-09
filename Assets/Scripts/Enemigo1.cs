using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
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
    }

}
