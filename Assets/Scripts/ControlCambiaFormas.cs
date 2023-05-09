using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCambiaFormas : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 500.0f;
    public float scaleChange = 0.1f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private float scaleValue = 1.0f;
    public GameObject Player2;
    public GameObject ladderModel;
    public float transformTime = 1.0f;

    private bool isTransformed = false;
    private bool hasTransformed = false;
    private float currentTransformTime = 0.0f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = Player2.transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !hasTransformed)
        {
            if (!isTransformed)
            {
                StartCoroutine(TransformToLadder());
            }
            else
            {
                StartCoroutine(TransformToPlayer());
            }
            hasTransformed = true;
        }
    }

    IEnumerator TransformToLadder()
    {
        currentTransformTime = 0.0f;

        while (currentTransformTime < transformTime)
        {
            currentTransformTime += Time.deltaTime;
            float t = currentTransformTime / transformTime;
            Player2.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
            ladderModel.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
            yield return null;
        }

        Player2.SetActive(false);
        ladderModel.SetActive(true);
        isTransformed = true;
    }

    IEnumerator TransformToPlayer()
    {
        currentTransformTime = 0.0f;

        while (currentTransformTime < transformTime)
        {
            currentTransformTime += Time.deltaTime;
            float t = currentTransformTime / transformTime;
            Player2.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
            ladderModel.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
            yield return null;
        }

        Player2.SetActive(true);
        ladderModel.SetActive(false);
        isTransformed = false;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            scaleValue += scaleChange;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            scaleValue -= scaleChange;
            transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
/*
public GameObject Player2;
public GameObject ladderModel;
public float transformTime = 1.0f;

private bool isTransformed = false;
private float currentTransformTime = 0.0f;
private Vector3 originalScale;

void Start()
{
    originalScale = playerModel.transform.localScale;
}

void Update()
{
    if (Input.GetKeyDown(KeyCode.T))
    {
        if (!isTransformed)
        {
            StartCoroutine(TransformToLadder());
        }
        else
        {
            StartCoroutine(TransformToPlayer());
        }
    }
}

IEnumerator TransformToLadder()
{
    currentTransformTime = 0.0f;

    while (currentTransformTime < transformTime)
    {
        currentTransformTime += Time.deltaTime;
        float t = currentTransformTime / transformTime;
        playerModel.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
        ladderModel.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
        yield return null;
    }

    playerModel.SetActive(false);
    ladderModel.SetActive(true);
    isTransformed = true;
}

IEnumerator TransformToPlayer()
{
    currentTransformTime = 0.0f;

    while (currentTransformTime < transformTime)
    {
        currentTransformTime += Time.deltaTime;
        float t = currentTransformTime / transformTime;
        playerModel.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
        ladderModel.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);
        yield return null;
    }

    playerModel.SetActive(true);
    ladderModel.SetActive(false);
    isTransformed = false;
}*/