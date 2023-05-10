using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float balaSpeed = 10f;

    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private float _fireRate = 2f;

    private float _fireTimer = 0f;

    [SerializeField]
    private float balaLifetime = 5f;

    private void Update()
    {
        // Apuntar hacia el objetivo
        Vector3 targetOrientation = _target.position - transform.position;
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetOrientationQuaternion, Time.deltaTime);

        // Disparar si se ha cumplido el tiempo de espera
        _fireTimer += Time.deltaTime;
        if (_fireTimer >= _fireRate)
        {
            _fireTimer = 1f;
            Disparar();
        }
    }

    private void Disparar()
    {
        // Instanciar la bala y apuntar hacia el objetivo
        //GameObject bulletObject = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity);
        //Vector3 targetOrientation = _target.position - _spawnPoint.position;
        //Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        //bulletObject.transform.rotation = targetOrientationQuaternion;
        GameObject balaGO = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity);
        Vector3 targetOrientation = _target.position - _spawnPoint.position;
        Quaternion targetOrientationQuaternion = Quaternion.LookRotation(targetOrientation);
        Rigidbody balaRB = balaGO.GetComponent<Rigidbody>();
        balaRB.velocity = (_target.position - transform.position).normalized * balaSpeed;

        Destroy(balaGO, balaLifetime);
    }
}
