using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    

    public float rangoAlerta;
    public LayerMask capaJugador;
    bool estarAlerta;
    public Transform jugador;
    public float velocidad;

    void Start()
    {
        
    }

    void Update()
    {
        //estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);

        //if (estarAlerta == true)
        //{
        //    Vector2 posJugador = new Vector2(jugador.position.x, transform.position.y, jugador.position.z);
        //    transform.LookAt(posJugador);
        //    transform.position = Vector2.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
        //}

    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    
    }
}
