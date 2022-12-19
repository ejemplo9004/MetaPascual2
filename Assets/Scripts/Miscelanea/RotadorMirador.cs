using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// El prop�sito de esta clase es que las turbinas miren hacia las manos
/// b�sicamente hace un LookAt on una rotaci�n en desface 
/// </summary>
public class RotadorMirador : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(offset);
    }
}
