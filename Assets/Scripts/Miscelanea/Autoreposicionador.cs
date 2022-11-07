using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoreposicionador : MonoBehaviour
{
    public Transform referencia;
    
    Vector3 offset;
    void Start()
    {
        offset = referencia.position - transform.position;    
    }

    void Update()
    {
        transform.position = referencia.position - offset;
    }
}
