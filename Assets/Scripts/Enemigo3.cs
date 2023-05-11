using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    public float rangoDeVision = 10f;
    public float velocidadOrbita = 2f;
    public float distanciaOrbita = 3f;


    private Transform _jugador;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_jugador != null)
        {
            // Si el jugador sigue dentro del rango de visión, seguir orbitando
            if (Vector3.Distance(transform.position, _jugador.position) < rangoDeVision)
            {
                transform.LookAt(_jugador);
                transform.RotateAround(_jugador.position, Vector3.up, velocidadOrbita * Time.deltaTime);
                transform.position = _jugador.position + transform.forward * -distanciaOrbita;
                _rb.MovePosition(transform.position);
            }
            // Si el jugador se aleja del rango de visión, dejar de orbitar
            else
            {
                _jugador = null;
            }
        }
        else
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, rangoDeVision);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Player"))
                {
                    _jugador = collider.transform;
                    break;
                }
            }
        }
    }
}
