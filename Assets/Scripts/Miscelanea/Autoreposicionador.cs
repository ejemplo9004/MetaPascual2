using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoreposicionador : MonoBehaviour
{
    public Transform referencia;
    
    public Vector3 offset;
    [ContextMenu("Calcular offset")]
    public void CalcularOffset()
    {
        offset = referencia.position - transform.position;    
    }

    void Update()
    {
        transform.position = referencia.position - offset;
    }
}
